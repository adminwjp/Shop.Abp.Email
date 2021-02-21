using System;
using System.Linq;
using Abp;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.EmbeddedResources;
using Abp.AspNetCore.Mvc.Extensions;
using Abp.AspNetCore.Mvc.Providers;
using Abp.Dependency;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Utility.Json;
using Microsoft.Extensions.Logging;
using Shop.EntityFrameworkCore.Repositories;
using Utility.Ef;
using Utility;
using Steeltoe.Discovery.Client;
using Utility.AspNetCore.Extensions;
using Utility.AspNetCore.Filter;
using Utility.AspNetCore;

namespace Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //注册微服务 
            services.AddRegisterService(Configuration,ServiceConfig.Flag);
            
            Utility.AspNetCore.Extensions.ServiceCollectionExtensions.AddApiVersioning(services);
          
            services.AddFilter()
            //全局配置Json序列化处理 方案1
            .AddJson()
          .SetCompatibilityVersion(CompatibilityVersion.Latest);
           services.AddControllers().AddControllersAsServices();
            services.AddSwagger<EmptySwaggerOperationFilter>("V1","Shop.Email.Api");
            string sqlConnectionString = Configuration.GetConnectionString($"{DbConfig.Flag}ConnectionString");
            Shop.ShopEmailDataModule.ConnectionString = sqlConnectionString;
            //Could not resolve DbContextOptions for Shop.EntityFrameworkCore.Repositories.EmailDbContext
            //The configured execution strategy 'MySqlRetryingExecutionStrategy' does not support user initiated transactions 调试 麻烦 源码 要 拉取对应版本
            services.UseEf<EmailDbContext>(sqlConnectionString); //abp 起冲突 多数据库 sqlite sqlserver mysql oracle postgre //直接 dbcontext 直接 声明数据库使用类型
          
            //重置 了 没啥用 
            //return  services.AddAbp<ShopModule>(); //Configure Abp and Dependency Injection 扔掉 了很多东西 不然 不知道 怎么改动
            AbpBootstrapper abpBootstrapper = AbpBootstrapper.Create<ShopEmailWebApiModule>();
            services.AddSingleton(abpBootstrapper);
            ConfigureAspNetCore(services, abpBootstrapper.IocManager);
            return WindsorRegistrationHelper.CreateServiceProvider(abpBootstrapper.IocManager.IocContainer, services);
        }
        private static void ConfigureAspNetCore(IServiceCollection services, IIocResolver iocResolver)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            services.Replace(ServiceDescriptor.Singleton<IPageModelActivatorProvider, ServiceBasedPageModelActivatorProvider>());
            services.Replace(ServiceDescriptor.Singleton<IViewComponentActivator, ServiceBasedViewComponentActivator>());
            services.GetSingletonServiceOrNull<ApplicationPartManager>()?.FeatureProviders.Add(new AbpAppServiceControllerFeatureProvider(iocResolver));

            services.Configure((Action<MvcOptions>)delegate (MvcOptions mvcOptions)
            {
                //mvcOptions.AddAbp(services); 只能反射 internal
            });
            services.Insert(0, ServiceDescriptor.Singleton((IConfigureOptions<MvcRazorRuntimeCompilationOptions>)new ConfigureOptions<MvcRazorRuntimeCompilationOptions>((Action<MvcRazorRuntimeCompilationOptions>)delegate (MvcRazorRuntimeCompilationOptions options)
            {
                options.FileProviders.Add(new EmbeddedResourceViewFileProvider(iocResolver));
            })));
            services.AddHttpClient("WebhookSenderHttpClient");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.Extensions.Hosting.IApplicationLifetime lifetime, ILoggerFactory loggerFactory)
        {
            app.UseAbp();//Initializes ABP framework.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHealthChecks("/liveness", new HealthCheckOptions
            //{
            //    Predicate = r => r.Name.Contains("self")
            //});

            //app.UseHealthChecks("/hc", new HealthCheckOptions()
            //{
            //    Predicate = _ => true,
            //    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //});
            // app.UseAuthorization();
			StartHelper.ApplicationStarted = lifetime.ApplicationStarted;
            StartHelper.ApplicationStopped = lifetime.ApplicationStopped;
            StartHelper.ApplicationStopping = lifetime.ApplicationStopping;
            app.UseService(Configuration, ServiceConfig.Flag);
            app.Use(env, "Shop.Email.Api");
        }
    }
}
