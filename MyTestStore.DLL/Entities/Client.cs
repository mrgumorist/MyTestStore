using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyTestStore.DLL.Entities
{
    public class Client
    {
        [Required, Key]
        public int ID { get; set; }
        public string FIO { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime Registered { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}
