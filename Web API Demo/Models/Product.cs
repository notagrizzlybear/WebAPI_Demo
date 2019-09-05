using System;

namespace Web_API_Demo.Models
{
    public class Product
    {
        public Guid ID { get; set; }
        public string Name { get; set; }  // converted to nvarchar
        public decimal Price { get; set; }

        public bool IsValid()
        {
            if(Name.Length > 100 || Name.Length == 0)
            {
                return false;
            }

            if(Price < 0M)
            {
                return false;
            }

            return true;
        }
    }
}
