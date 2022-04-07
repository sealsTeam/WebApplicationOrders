using Microsoft.EntityFrameworkCore;
using WebApplicationOrders.Models;

namespace WebApplicationOrders.Data
{
    public class PagesProductsContext : DbContext
    {
        public PagesProductsContext (DbContextOptions<PagesProductsContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Order> Order { get; set; }

    }
}
