using Abp.AspNetCore.Mvc.ViewComponents;

namespace MyEcommerce.Web.Views
{
    public abstract class MyEcommerceViewComponent : AbpViewComponent
    {
        protected MyEcommerceViewComponent()
        {
            LocalizationSourceName = MyEcommerceConsts.LocalizationSourceName;
        }
    }
}
