using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyEcommerce.Configuration;

namespace MyEcommerce.Web.Host.Startup
{
    [DependsOn(
       typeof(MyEcommerceWebCoreModule))]
    public class MyEcommerceWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public MyEcommerceWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyEcommerceWebHostModule).GetAssembly());
        }
    }
}
