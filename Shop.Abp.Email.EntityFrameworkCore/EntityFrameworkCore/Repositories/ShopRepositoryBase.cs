using Abp.Domain.Entities;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Linq.Expressions;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Z.EntityFramework.Plus;

namespace Shop.EntityFrameworkCore.Repositories
{
    public abstract class ShopRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<EmailDbContext,TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ShopRepositoryBase(IDbContextProvider<EmailDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        //add common methods for all repositories

      
    }

    public abstract class ShopRepositoryBase<TEntity> : ShopRepositoryBase<TEntity, string>
        where TEntity : BaseEntity,new()
    {
        protected ShopRepositoryBase(IDbContextProvider<EmailDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }
        //MySqlRetryingExecutionStrategy' does not support user initiated transactions service 使用 UnitOfWork
        [UnitOfWork]
        public override TEntity Insert(TEntity entity)
        {
            entity.Id = Guid.NewGuid().ToString("N");
            return base.Insert(entity);
        }

        protected virtual Expression<Func<TEntity,bool>> GetWhere(TEntity entity)
        {
            Expression < Func<TEntity, bool> > where =it=>it.IsDeleted==false;
            if (!string.IsNullOrEmpty(entity.Id))
            {
                where= where.Or(it=>it.Id==entity.Id);
            }
            return where;
        }
        public virtual IList<TEntity> Find(TEntity entity)
        {
            var where = GetWhere(entity);
            return GetAll().OrderBy(it=>it.CreationTime).Where(where).ToList();
        }

        //MySqlRetryingExecutionStrategy' does not support user initiated transactions
        [UnitOfWork]
        public override void Delete(string id)
        {
            base.GetAll().Where(it => it.Id == id && !it.IsDeleted).Update(it => new TEntity() { IsDeleted = true, DeletionTime = DateTime.Now });
        }
        public virtual IList<TEntity> FindByPage(TEntity entity,int page,int size)
        {
            var where = GetWhere(entity);
            return GetAll().OrderBy(it => it.CreationTime).Where(where).Skip((page-1)*size).Take(size).ToList();
        }
        public virtual int Count(TEntity entity)
        {
            var where = GetWhere(entity);
            return GetAll().Where(where).Count();
        }
        //MySqlRetryingExecutionStrategy' does not support user initiated transactions
        [UnitOfWork]
        public override TEntity Update(TEntity entity)
        {
            //已删除 的不能 修改
            var old = base.GetAll().Where(it => it.Id == entity.Id&&!it.IsDeleted).Select(it=>new { it.CreationTime,it.DeletionTime,it.IsDeleted }).FirstOrDefault();
            if (old == null)
            {
                throw new Exception("not exists!");
            }
            entity.CreationTime = old.CreationTime;
            //entity.LastModificationTime = DateTime.Now;
            entity.IsDeleted = old.IsDeleted;
            entity.DeletionTime = old.DeletionTime;
            return base.Update(entity);

        }

        //do not add any method here, add to the class above (since this inherits it)
        //MySqlRetryingExecutionStrategy' does not support user initiated transactions
        [UnitOfWork]
        public void Delete(string[] ids)
        {
            Expression<Func<TEntity, bool>> where = null;
            for (int i = 0; i < ids.Length; i++)
            {
                if (where == null)
                {
                    where = it => it.Id == ids[i];
                }
                else
                {
                    where = where.Or(it => it.Id == ids[i]);
                }
            }
           // base.Delete(where);
            base.GetAll().Where(where).Update(it=>new TEntity() { IsDeleted=true,DeletionTime= DateTime.Now});
        }
    }
}