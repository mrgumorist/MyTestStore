using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestStore.Domain.Models
{
    public class ActionResult
    {
        public ActionResult()
        {

        }
        public ActionResult(bool IsSuccessfull, string Description)
        {
            this.IsSuccessfull = IsSuccessfull;
            this.Description = Description;
        }
        public ActionResult(bool IsSuccessfull, string Description, string Data)
        {
            this.IsSuccessfull = IsSuccessfull;
            this.Description = Description;
            this.Data = Data;
        }
        public ActionResult(bool IsSuccessfull, string Description, string Data, object Object)
        {
            this.IsSuccessfull = IsSuccessfull;
            this.Description = Description;
            this.Data = Data;
            this.ResObj = Object;
        }
        public bool IsSuccessfull { get; set; } = false;
        public string Description { get; set; } = "";
        public string Data { get; set; } = "";
        public object ResObj { get; set; } = null;
    }
}
