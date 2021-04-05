using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public decimal Price{ get; set; }
        public int Amount{ get; set; }
        public string CreatedBy { get; set; }
    }
}
