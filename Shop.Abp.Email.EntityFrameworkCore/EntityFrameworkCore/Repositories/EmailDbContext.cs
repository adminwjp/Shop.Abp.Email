using Microsoft.EntityFrameworkCore;
using Shop.EmailNotifyProducts;
using Shop.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;
using Utility.Ef;

namespace Shop.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// 产品 数据库 上下文
    /// </summary>
    public class EmailDbContext:DbContext
    {
        public EmailDbContext(DbContextOptions<EmailDbContext> options):base(options)
        {
            //Database.CreateExecutionStrategy();
        }

        public static DbContextOptionsBuilder Parse(DbFlag flag, string connectionString, DbContextOptionsBuilder bulder)
        {
            switch (flag)
            {
                case DbFlag.MySql:
                    return bulder.UseMySql(connectionString);
                //case DbFlag.SqlServer:
                //    return bulder.UseSqlServer(connectionString);
                //case DbFlag.Oracle:
                //    return bulder.UseOracle(connectionString);
                //case DbFlag.Postgre:
                //    return bulder.UseNpgsql(connectionString);
                //case DbFlag.Sqlite:
                //    return bulder.UseSqlite(connectionString);
                default:
                    return bulder;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Parse(DbConfig.Flag, ConnectionHelper.ConnectionString, optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// 不给 注释 mapp 该 属性 名称 就是 表名 ef core
        /// </summary>
        public DbSet<Email> Emails { get; set; }
        public DbSet<EmailNotifyProduct> EmailNotifyProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>(entity =>
            {
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Id).HasColumnName("id").HasMaxLength(36);
                if (DbConfig.Flag == DbFlag.MySql)
                {
                    entity.Property(it => it.StartTime).HasColumnName("start_time").HasColumnType("datetime");
                    entity.Property(it => it.EndTime).HasColumnName("end_time").HasColumnType("datetime");
                    entity.Property(it => it.CreationTime).HasColumnName("creation_time").HasColumnType("datetime");
                    entity.Property(it => it.LastModificationTime).HasColumnName("last_modification_time").HasColumnType("datetime");
                    entity.Property(it => it.DeletionTime).HasColumnName("deletion_time").HasColumnType("datetime");
                }
                entity.Property(it => it.IsDeleted).HasColumnName("is_deleted");
            });
            modelBuilder.Entity<EmailNotifyProduct>(entity =>
            {
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Id).HasColumnName("id").HasMaxLength(36);
                if (DbConfig.Flag == DbFlag.MySql)
                {
                    entity.Property(it => it.NotifyDate).HasColumnName("notify_date").HasColumnType("datetime");
                    entity.Property(it => it.CreationTime).HasColumnName("creation_time").HasColumnType("datetime");
                    entity.Property(it => it.LastModificationTime).HasColumnName("last_modification_time").HasColumnType("datetime");
                    entity.Property(it => it.DeletionTime).HasColumnName("deletion_time").HasColumnType("datetime");
                }
                entity.Property(it => it.IsDeleted).HasColumnName("is_deleted");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
