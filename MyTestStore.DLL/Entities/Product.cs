using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTestStore.DLL.Entities
{
    public class Product
    {
        [Required, Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public double Price { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public ICollection<ProductInPurchase> ProductsInPurchase { get; set; }
    }
}
