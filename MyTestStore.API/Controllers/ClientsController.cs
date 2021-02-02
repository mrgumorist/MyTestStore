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
        public ActionResult GetClientInfo([FromBody]ClientModel clientModel)
        {
            Domain.Models.RequestResult requestRes = new Domain.Models.RequestResult();
            var result = _service.GetClientInfo(clientModel.ID);
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

        [Route("api/[controller]/GetClientsByBirth")]
        [HttpPost]
        public ActionResult GetClientsByBirth([FromBody]BirthDateModel model)
        {
            Domain.Models.RequestResult requestRes = new Domain.Models.RequestResult();
            var result = _service.GetClientByBirthDay(model.Date);
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


        [Route("api/[controller]/GetLastClients")]
        [HttpPost]
        public ActionResult GetLastClients([FromBody]DayCountModel model)
        {
            Domain.Models.RequestResult requestRes = new Domain.Models.RequestResult();
            if(model.Days>=0)
            {
                var result = _service.GetLastClients(model.Days);
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
            }
            else
            {
                requestRes.IsSuccessfull = false;
                requestRes.Message = "Error: Days count is not valid.";
            }
            return Ok(requestRes);
        }
    }
}