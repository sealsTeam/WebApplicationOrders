using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
    public class PagesProductsContext : DbContext
    {
        public PagesProductsContext (DbContextOptions<PagesProductsContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}
