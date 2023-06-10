using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using MyEcommerce.EntityFrameworkCore;
using MyEcommerce.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace MyEcommerce.Web.Tests
{
    [DependsOn(
        typeof(MyEcommerceWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class MyEcommerceWebTestModule : AbpModule
    {
        public MyEcommerceWebTestModule(MyEcommerceEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(MyEcommerceWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(MyEcommerceWebMvcModule).Assembly);
        }
    }
}