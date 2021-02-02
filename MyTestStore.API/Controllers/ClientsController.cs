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
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _service;
        public ClientsController(IClientsService service)
        {
            this._service = service;
        }

        [Route("api/[controller]/GetClientInfo")]
        [HttpPost]
        public ActionResult GetCopartModels([FromBody]ClientModel clientModel)
        {
            Domain.Models.RequestResult requestRes = new Domain.Models.RequestResult();
            var result = _service.GetClientInfo(clientModel.ID);
            if (result.IsSuccessfull == true)
            {
                requestRes.IsSuccessfull = true;
                requestRes.Message = result.Description;
                requestRes.Object = result.ResObj;
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