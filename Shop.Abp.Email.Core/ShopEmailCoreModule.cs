using Abp.Modules;
using Castle.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class ShopEmailCoreModule: AbpModule
    {
        public override void Initialize()
        {
            IocManager.Register<ILogger, ConsoleLogger>();
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
