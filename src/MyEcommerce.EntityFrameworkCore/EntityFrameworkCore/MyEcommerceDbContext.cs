using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyEcommerce.Authorization.Roles;
using MyEcommerce.Authorization.Users;
using MyEcommerce.MultiTenancy;
using MyEcommerce.Entities;
using MyEcommerce.Entities.Categories;

namespace MyEcommerce.EntityFrameworkCore
{
    public class MyEcommerceDbContext : AbpZeroDbContext<Tenant, Role, User, MyEcommerceDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }

        public MyEcommerceDbContext(DbContextOptions<MyEcommerceDbContext> options)
            : base(options)
        {
        }
    }
}
