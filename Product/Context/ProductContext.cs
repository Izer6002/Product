using Microsoft.EntityFrameworkCore;
using Product.Models;

namespace Product.Context
{
    public class ProductContext : DbContext
    {
        public DbSet<ProductModel> Product { get; set; }

        public DbSet<OrderModel> Order { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}
