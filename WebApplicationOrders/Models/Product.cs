using System;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
    }
}