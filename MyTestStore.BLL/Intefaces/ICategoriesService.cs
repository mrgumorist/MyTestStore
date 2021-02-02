using MyTestStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestStore.BLL.Intefaces
{
    public interface ICategoriesService
    {
        public ActionResult GetInDemandCategories(int clientID);
    }
}
