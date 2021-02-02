using MyTestStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestStore.BLL.Intefaces
{
    public interface IClientsService
    {
        public ActionResult GetClientInfo(int ID);
        public ActionResult GetClientByBirthDay(DateTime date);
    }
}
