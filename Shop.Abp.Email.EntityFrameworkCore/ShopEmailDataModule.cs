using Abp.Domain.Uow;
using Abp.EntityFrameworkCore;
using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Utility;
using Utility.Config;

namespace Shop
{
    [DependsOn(typeof(ShopEmailCoreModule),typeof(AbpEntityFrameworkCoreModule))]
    public class ShopEmailDataModule: AbpModule
    {
        /// <summary>
        /// 数据库连接地址 每次地址改变 麻烦 直接静态更新 
        /// </summary>
        public static string ConnectionString { get; set; }

        public override void PreInitialize()
        {
            //网上说 需要安装 System.Configuration.ConfigurationManager package 支持 web.config 读取不到
            //net core 读取 不到  web.config  只能读取 app.config 多地址不能这样用了
            //需要安装包才能读取到 json 文件 ,安装包  web.config aapp.config 读取不到 asp.net core 读取得到 包环境问题
            //string connectionString = Utility.ConnectionHelper.ConnectionString;
            //读写分离怎么实现 abp 要么部署多个模块 不改代码前提下 每个模块对应一个地址 读话 
            //迁移 注意 下 netstand 下不能迁移 netcore 环境下支持
            //在 ef  这个参数没用  dapper 
            //Abp.AbpException: Could not find a connection string definition for the application. Set IAbpStartupConfiguration.DefaultNameOrConnectionString or add a 'Default' 
            //connection string to application .config file.
            if (string.IsNullOrEmpty(ConnectionString))
            {
                //模块加载 必须这里获取 反射机制
                string key = $"ShopEmail/{DbConfig.Flag}ConnectionString";
                //An error occurred using the connection to database mysql ip 写错了
                //Option 'integrated security' not supported.
                //Integrated Security=False;
                ConnectionString = ConfigManager.GetByConsul(key);
            }
            
            Configuration.DefaultNameOrConnectionString = ConnectionString;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
