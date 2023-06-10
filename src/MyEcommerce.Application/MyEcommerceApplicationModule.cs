using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyEcommerce.Authorization;

namespace MyEcommerce
{
    [DependsOn(
        typeof(MyEcommerceCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class MyEcommerceApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<MyEcommerceAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(MyEcommerceApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
