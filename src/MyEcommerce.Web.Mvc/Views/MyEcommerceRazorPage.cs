using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace MyEcommerce.Web.Views
{
    public abstract class MyEcommerceRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected MyEcommerceRazorPage()
        {
            LocalizationSourceName = MyEcommerceConsts.LocalizationSourceName;
        }
    }
}
