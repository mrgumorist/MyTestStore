using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyTestStore.API.Models;
using MyTestStore.BLL.Intefaces;

namespace MyTestStore.API.Controllers
{
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _service;

        public CategoriesController(ICategoriesService service)
        {
            this._service = service;
        }

        [Route("api/[controller]/GetInDemandCategories")]
        [HttpPost]
        public ActionResult GetInDemandCategories([FromBody]ClientModel clientModel)
        {
            Domain.Models.RequestResult requestRes = new Domain.Models.RequestResult();
            var result = _service.GetInDemandCategories(clientModel.ID);
            if (result.IsSuccessfull == true)
            {
                requestRes.IsSuccessfull = true;
                requestRes.Message = result.Description;
                requestRes.ResultData = result.ResObj;
            }
            else
            {
                requestRes.IsSuccessfull = false;
                requestRes.Message = result.Description;
            }
            return Ok(requestRes);
        }
    }
}