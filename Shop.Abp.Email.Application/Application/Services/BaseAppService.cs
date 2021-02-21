using Abp.Application.Services;
using Abp.ObjectMapping;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Abp.Net.Mail;
using Shop.Domain.Repositories;
using Shop.Domain.Entities;
using Abp.Domain.Uow;
using System;
using Shop.Application.Services.Dtos;

namespace Shop.Application.Services
{
    /// <summary>
    /// 邮件 基础 服务 
    ///  定时发送邮件 默认 就发送
    ///  使用 aop 实现缓存
    /// </summary>
    public class BaseAppService<Repository, Entity, CreateInput,UpdateInput, Input,Output>:ApplicationService
        where Repository :IBaseRepository<Entity>
        where Entity : BaseEntity
        where CreateInput:class
        where UpdateInput : class, IUpdateInput
        where Output : class
        where Input : class
     
    {
        public  string RedisKey = "email";
        protected Repository repository;
        //protected CacheBase cache;
        ////protected ICacheManager cacheManager;
        //protected IDatabase database;
        protected ILogger logger;
        //protected IEmailSender emailSender;

        public BaseAppService(Repository repository, IObjectMapper objectMapper,ILogger logger):this(repository,objectMapper,null,null,logger,null)
        {

        }
        public BaseAppService(Repository repository, IObjectMapper objectMapper, string cacheManager, string abpRedisCacheDatabaseProvider,
            ILogger logger, IEmailSender emailSender)
        {
 
            this.repository = repository;
            this.ObjectMapper = objectMapper;
            // this.cache = (AbpRedisCache)(cacheManager.GetCache("RedisCache"));
           /* ICache cacheTemp = cacheManager.GetCache("RedisCache");
            if(cacheTemp is AbpRedisCache)
            {
                this.cache = (AbpRedisCache)cacheTemp;//AbpMemoryCache
            }
            else
            {
                this.cache = (AbpMemoryCache)cacheTemp;//AbpMemoryCache
            }
            this.database = abpRedisCacheDatabaseProvider.GetDatabase();
            this.logger = logger;
            this.emailSender = emailSender;*/
        }

        /// <summary>
        /// 添加 
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        //[UnitOfWork]
        public virtual int Insert(CreateInput create)
        {
            Entity entity = ObjectMapper.Map<Entity>(create);
            entity.CreationTime = DateTime.Now;
            try
            {
                //The configured execution strategy 'MySqlRetryingExecutionStrategy' does not support user initiated transactions.
                //Use the execution strategy returned by 'DbContext.Database.CreateExecutionStrategy()' to execute all the operations in the transaction as a retriable unit.
                //UnitOfWorkInterceptor  InterceptSynchronous ?  EfCoreUnitOfWork UnitOfWorkBase Complete() SaveChanges() 异常 没有具体位置
                //AbpPlugInManager RegisterToAssemblyResolve()
                var entity1 = repository.Insert(entity);
            }finally
            //catch (System.Exception e)
            {

               // throw e;
            }
           // int hash = HashHelper.GetGuidHashCode(entity.Id);
          /*  if(!this.database.StringSetBit(RedisKey, hash, true))
            {
                logger.LogInformation("insert -> bool filter set fail:{Id}-{Hash}", entity.Id,hash);
                try
                {
                    //Send a notification email
                    emailSender.SendAsync(
                        to: ConfigurationManager.AppSettings["email"],
                        subject: "insert -> bool filter set fail",
                        body: $"insert -> bool filter set fail:<b>{entity.Id}-{hash}</b><p>detail:{entity.ToJsonString()}</>",
                        isBodyHtml: true
                    );
                }
                catch { }
            }*/
            return 1;
        }

        /// <summary>
        /// 修改 邮件
        /// </summary>
        /// <param name="create"></param>
        /// <returns></returns>
        //[UnitOfWork]
        public virtual int Update(UpdateInput update)
        {
            var destination = repository.Get(update.Id);
            Entity entity = ObjectMapper.Map(update, destination);
            entity.LastModificationTime = DateTime.Now;
            int hash = HashHelper.GetGuidHashCode(entity.Id);
           /* if (!this.database.StringGetBit(RedisKey, hash))
            {
                logger.LogInformation("update -> bool filter get fail:{Id}-{Hash}", entity.Id, hash);
                try
                {
                    //Send a notification email
                    emailSender.SendAsync(
                        to: ConfigurationManager.AppSettings["email"],
                        subject: "update -> bool filter  get fail",
                        body: $"bool filter get fail:<b>{entity.Id}-{hash}</b><p>detail:{entity.ToJsonString()}</>",
                        isBodyHtml: true
                    );
                }
                catch { }
                return -1;
            }*/
            //已删除 的不能 修改
            repository.Update(entity);
            return 1;
        }
        //[UnitOfWork]
        public virtual void Delete(string id)
        {
            int hash = HashHelper.GetGuidHashCode(id);
            /*if (!this.database.StringGetBit(RedisKey, hash))
            {
                logger.LogInformation("delete -> bool filter get fail:{Id}-{Hash}", id, hash);
                //Send a notification email
                emailSender.SendAsync(
                    to: ConfigurationManager.AppSettings["email"],
                    subject: "delete -> bool filter  get fail",
                    body: $"delete ->bool filter get fail:<b>{id}-{hash}</b>",
                    isBodyHtml: true
                );
                return;
            }*/
            repository.Delete(id);
           /* if (!this.database.StringSetBit(RedisKey, hash, false))
            {
                logger.LogInformation("bool filter delete fail:{Id}-{Hash}", id, hash);
                try
                {
                    //Send a notification email
                    emailSender.SendAsync(
                        to: ConfigurationManager.AppSettings["email"],
                        subject: "delete -> bool filter  set fail",
                        body: $"delete ->bool filter set fail:<b>{id}-{hash}</b>",
                        isBodyHtml: true
                    );
                }
                catch { }
            }*/
        }
        
        public virtual IList<Output> Find()
        {
            var res = repository.GetAllList();
            var result = ObjectMapper.Map<IList<Output>>(res);
            return result;
        }

       // [UnitOfWork]
        public virtual void Delete(string[] ids)
        {
            List<string> id = new List<string>(ids.Length);
            //logger.LogInformation("bool filter get :{Id}", ids);
            //foreach (var item in ids)
            //{
            //    int hash = HashHelper.GetGuidHashCode(item);
            //    if (this.database.StringGetBit(RedisKey, hash))
            //    {
            //        id.Add(item);
            //    }
            //    else
            //    {
            //        logger.LogInformation("bool filter get fail:{Id}-{Hash}", item, hash);
            //    }
            //}
            //if (id.Count == 0)
            //{
            //    return;
            //}
            repository.Delete(id.ToArray());
            //foreach (var item in ids)
            //{
            //    int hash = HashHelper.GetGuidHashCode(item);
            //    if (!this.database.StringSetBit(RedisKey, hash, false))
            //    {
            //        logger.LogInformation("bool filter delete fail:{Id}-{Hash}", item, hash);
            //    }
            //}
        }
        public virtual IList<Output> Find(Input entity)
        {
            Entity email = ObjectMapper.Map<Entity>(entity);
            var res = repository.Find(email);
            var result = ObjectMapper.Map<IList<Output>>(res);
            return result;
        }

        public virtual IList<Output> FindByPage(Input entity, int page = 1, int size = 10)
        {
            Entity order = ObjectMapper.Map<Entity>(entity);
            var res = repository.FindByPage(order, page, size);
            var result = ObjectMapper.Map<IList<Output>>(res);
            return result;
        }

        public virtual int Count(Input entity)
        {
            Entity email = ObjectMapper.Map<Entity>(entity);
            var res = repository.Count(email);
            return res;
        }
    }
}
