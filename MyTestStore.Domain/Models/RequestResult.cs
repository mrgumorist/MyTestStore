using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestStore.Domain.Models
{
    public class RequestResult
    {
        public bool IsSuccessfull { get; set; } = false;
        public string Message { get; set; } = "";
        public string Data { get; set; } = "";
        public object ResultData { get; set; } = null;
    }
}
