using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOrders.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }

        public decimal? Price { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

    }
}