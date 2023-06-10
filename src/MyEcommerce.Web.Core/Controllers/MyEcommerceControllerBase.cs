using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace MyEcommerce.Controllers
{
    public abstract class MyEcommerceControllerBase: AbpController
    {
        protected MyEcommerceControllerBase()
        {
            LocalizationSourceName = MyEcommerceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
