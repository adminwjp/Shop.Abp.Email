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
            //����1 ��ҪӲ����
            //pass
            ServiceConfig.Flag = ServiceFlag.None;//ʹ�ö�̬���� �˿� û��
            IConfiguration configuration = LogHelper.Initial();


            //���� 2
            ServiceConfig.Flag = ServiceFlag.Consul;
            //IConfigurationBuilder configurationBuilder = LogHelper.Builder(false);
            //IConfiguration configuration = configurationBuilder.Build();
            //LogHelper.DynamicConfig(configurationBuilder, ServiceConfig.Flag,configuration["Consul_Key"],configuration["Consul_Url"]);
            // configuration = LogHelper.LogConfig(configurationBuilder.Build());

            //ʲô���� �˿� ��ôû�� ���� ԭ��?
            StartHelper.CreateWebHostBuilder<Startup>(configuration, args).Run();
           
        }

      
    }
}
