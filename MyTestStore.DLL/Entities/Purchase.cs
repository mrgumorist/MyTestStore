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
        public string UniqueNumber { get; set; }
        public DateTime Date { get; set; }

        public ICollection<ProductInPurchase> Products { get; set; }

        public int ClientID { get; set; }
        public Client Client { get; set; }
    }
}
