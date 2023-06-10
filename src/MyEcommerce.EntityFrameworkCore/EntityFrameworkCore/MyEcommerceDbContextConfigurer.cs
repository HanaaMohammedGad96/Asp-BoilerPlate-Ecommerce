using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace MyEcommerce.EntityFrameworkCore
{
    public static class MyEcommerceDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<MyEcommerceDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<MyEcommerceDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
