using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestStore.BLL.DTOs
{
    public class ClientInfoDTO
    {
        public int ID { get; set; }
        public string FIO { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime Registered { get; set; }
    }
}
