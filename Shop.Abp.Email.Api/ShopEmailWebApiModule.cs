using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace Shop
{

    /// <summary>
    /// doamin、数据访问层 ef 整合一起时 用这个
    /// </summary>
    [DependsOn(typeof(ShopEmailApplicationModule),typeof(AbpAspNetCoreModule))]
    public class ShopEmailWebApiModule : AbpModule
    {
        public override void PreInitialize()
        {

            Configuration.Modules.AbpAspNetCore().DefaultResponseCacheAttributeForAppServices = new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None };

            Configuration.IocManager.Resolve<IAbpAspNetCoreConfiguration>().EndpointConfiguration.Add(endpoints =>
            {
                endpoints.MapControllerRoute("defaultWithArea", "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Configuration.Modules.AbpAspNetCore().CreateControllersForAppServices(GetType().Assembly, "app");
        }
    }
}
