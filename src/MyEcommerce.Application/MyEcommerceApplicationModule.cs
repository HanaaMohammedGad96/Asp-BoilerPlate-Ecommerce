using Abp.AutoMapper;
using Abp.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AutoMapper;
using MyEcommerce.Authorization;
using MyEcommerce.Categories.Dto;
using MyEcommerce.Entities.Categories;

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
                cfg =>
                {
                    cfg.AddMaps(thisAssembly);
                    CustomDtoMapper.CreateMappings(cfg, new MultiLingualMapContext( IocManager.Resolve<ISettingManager>()));
                }
            );
        }
    }

    internal static class CustomDtoMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration, MultiLingualMapContext context)
        {
          configuration.CreateMultiLingualMap<Category, CategoryTranslation, CategoryListDto>(context);
        }
    }
}
