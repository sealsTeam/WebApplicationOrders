using WebApplicationOrders.Models;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationOrders.Models
{
    public class Order
    {
        public int Id { get; set; }

        public ICollection<Product> ItemOrdered { get; set; } 

        public string SenderCity { get; set; }

        public string RecipientCity { get; set; }

        public string SenderAddress { get; set; }

        public string AddressRecipient { get; set; }

        public double TotalWeight { get; set; }

        [DataType(DataType.Date)]
        public DateTime PickupDate { get; set; }

    }
}
