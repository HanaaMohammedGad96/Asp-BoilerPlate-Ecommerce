﻿using System.Threading.Tasks;
using MyEcommerce.Models.TokenAuth;
using MyEcommerce.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyEcommerce.Web.Tests.Controllers
{
    public class HomeController_Tests: MyEcommerceWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}