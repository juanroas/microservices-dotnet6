using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MySqlConnector;

namespace GeekShopping.ProductAPI.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string DbPath = "Server=localhost;DataBase=geek_shopping_product_api;Uid=root;Pwd=admin123;Pipelining=False;";
                optionsBuilder.UseMySql(
                       DbPath,
                        new MySqlServerVersion(new Version(8, 4, 3)),
                       options => options.EnableRetryOnFailure(2)
                   );
            }
        }
    }
}
