using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTestStore.DLL.Entities
{
    public class ProductInPurchase
    {
        [Required, Key]
        public int ID { get; set; }
        public int Count { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int PurchaseID { get; set; }
        public Purchase Purchase { get; set; }
    }
}
