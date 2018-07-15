using System;

namespace Renova.Models
{
    public class Product
    {
        public string Brand { get; set; }
        public string Category { get; set; }
        public int CostPrice { get; set; }
        public string Detail { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int SellingPrice { get; set; }

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
