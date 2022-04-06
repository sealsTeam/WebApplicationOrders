using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PagesProductsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<PagesProductsContext>>()))
            {
                
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }
                
                context.SaveChanges();
            }
        }
    }
}