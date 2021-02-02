using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTestStore.DLL.Entities
{
    public class Purchase
    {
        [Required, Key]
        public int ID { get; set; }
        public DateTime Date { get; set; }

        public ICollection<ProductInPurchase> Products { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }

        public double Sum { get; set; } = 0;
    }
}
