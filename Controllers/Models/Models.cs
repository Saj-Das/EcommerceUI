using System;

namespace Renova.Models
{
    public class Product
    {
        public string Brand { get; set; }
        public string Category { get; set; }
        public string CostPrice { get; set; }
        public string Detail { get; set; }
        public string ProductName { get; set; }
        public string Quantity { get; set; }
        public string SellingPrice { get; set; }

        public string Tags { get; set; }
    }
     public class User
    {
        public string Contact { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
      
    }
}
