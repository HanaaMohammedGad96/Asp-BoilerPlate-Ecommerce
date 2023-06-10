using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MyEcommerce.Controllers;

namespace MyEcommerce.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : MyEcommerceControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
