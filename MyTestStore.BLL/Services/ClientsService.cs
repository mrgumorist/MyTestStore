using AutoMapper;
using MyTestStore.BLL.DTOs;
using MyTestStore.BLL.Intefaces;
using MyTestStore.DLL.Entities;
using MyTestStore.DLL.Interfaces;
using MyTestStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTestStore.BLL.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IRepository<Client> _clientsRepository;
        private readonly IMapper _mapper;

        public ClientsService(IRepository<Client> clientsRepository, IMapper mapper)
        {
            this._clientsRepository = clientsRepository;
            this._mapper = mapper;
        }

        public ActionResult GetClientInfo(int ID)
        {
            ActionResult result = new ActionResult();
            try {
                var client = _clientsRepository.Get(ID);
                if(client!=null)
                {
                    var mappedClient = _mapper.Map<Client, ClientInfoDTO>(client);
                    result.Description = "Success";
                    result.IsSuccessfull = true;
                    result.ResObj = mappedClient;
                }
                else
                {
                    result.IsSuccessfull = false;
                    result.Description = "Client was not found";
                }
            }
            catch(Exception ex)
            {
                result.IsSuccessfull = false;
                result.Description = "Error: "+ ex.Message;
            }

            return result;
        }
    }
}
