using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyEcommerce.Authorization.Roles;
using MyEcommerce.Authorization.Users;
using MyEcommerce.MultiTenancy;

namespace MyEcommerce.EntityFrameworkCore
{
    public class MyEcommerceDbContext : AbpZeroDbContext<Tenant, Role, User, MyEcommerceDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public MyEcommerceDbContext(DbContextOptions<MyEcommerceDbContext> options)
            : base(options)
        {
        }
    }
}
