using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestStore.BLL.DTOs
{
    public class ClientWithLastPurchase
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public DateTime LastPurchase { get; set; }
    }
}
