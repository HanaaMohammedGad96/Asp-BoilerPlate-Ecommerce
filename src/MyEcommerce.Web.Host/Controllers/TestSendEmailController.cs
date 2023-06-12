using Abp.AspNetCore.Mvc.Controllers;
using Abp.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyEcommerce.Web.Host.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestSendEmailController : AbpController
    {
        private readonly IEmailSender _emailSender;
        public TestSendEmailController(IEmailSender emailSender)
        => _emailSender = emailSender;
        [HttpGet]
        public async Task<ActionResult> TestSendEmail()
        {
            string email = "hanaa.mohammed.gad@gmail.com";
            string subject = "Asp.Net Boilerplate";
            string body = $"Dear Hanaa 😍, your testing 🧪 has been successed🎇.";
           await  _emailSender.SendAsync(email, subject, body);
            return Ok("Hi 👋");
        }
    }
}
