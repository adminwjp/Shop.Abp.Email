using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Utility.AspNetCore;
using Utility;
using Winton.Extensions.Configuration.Consul;
using System.IO;
using Serilog;
using Microsoft.AspNetCore;

namespace Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Utility.Ef.EfConfig.IsAbpEf = true;
            DbConfig.Flag = DbFlag.MySql;
            Console.Title = "Shop.Email.Api";
            //方案1 需要硬编码
            //pass
            ServiceConfig.Flag = ServiceFlag.None;//使用动态配置 端口 没变
            IConfiguration configuration = LogHelper.Initial();


            //方案 2
            ServiceConfig.Flag = ServiceFlag.Consul;
            //IConfigurationBuilder configurationBuilder = LogHelper.Builder(false);
            //IConfiguration configuration = configurationBuilder.Build();
            //LogHelper.DynamicConfig(configurationBuilder, ServiceConfig.Flag,configuration["Consul_Key"],configuration["Consul_Url"]);
            // configuration = LogHelper.LogConfig(configurationBuilder.Build());

            //什么玩意 端口 怎么没变 程序集 原因?
            StartHelper.CreateWebHostBuilder<Startup>(configuration, args).Run();
           
        }

      
    }
}
