using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebApplicationOrders.Models
{
    public class OrderVM
    {
        public Order Order  { get; set; }

        public List<SelectListItem> ProductItems { get; set; }
    }
}
