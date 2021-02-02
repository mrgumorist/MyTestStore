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
        private readonly IRepository<Purchase> _purchaseRepository;
        private readonly IMapper _mapper;

        public ClientsService(IRepository<Client> clientsRepository, IRepository<Purchase> purchaseRepository, IMapper mapper)
        {
            this._clientsRepository = clientsRepository;
            this._mapper = mapper;
            this._purchaseRepository = purchaseRepository;
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

        public ActionResult GetClientByBirthDay(DateTime date)
        {
            ActionResult result = new ActionResult();
            try
            {
                var clients = _clientsRepository.Find(x=>x.BirthDay.Date == date.Date).ToList();
                if (clients.Count != 0)
                {
                    var mappedClients = _mapper.Map<List<Client>, List<ClientWithBirth>>(clients);
                    result.Description = "Success";
                    result.IsSuccessfull = true;
                    result.ResObj = mappedClients;
                }
                else
                {
                    result.IsSuccessfull = false;
                    result.Description = "Client was not found";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                result.Description = "Error: " + ex.Message;
            }
            return result;
        }

        public ActionResult GetLastClients(int days)
        {
            ActionResult result = new ActionResult();
            try
            {
                var purchases = _purchaseRepository.Find(x=>x.Date.Date>=DateTime.Now.Date.AddDays(-days)).GroupBy(x=>x.ClientID).Select(x=>x.First()).ToList();//(x => x.Purchases.LastOrDefault(l => l.Date.Date >= DateTime.Now.AddDays(-days).Date) != null).ToList();
                if (purchases.Count != 0)
                {
                    List<ClientWithLastPurchase> clients = new List<ClientWithLastPurchase>();
                    foreach (var item in purchases)
                    {
                        var tempClient = _clientsRepository.Get(item.ClientID);
                        ClientWithLastPurchase client = new ClientWithLastPurchase();
                        client.FIO = tempClient.FIO;
                        client.ID = tempClient.ID;
                        client.LastPurchase = item.Date;
                        clients.Add(client);
                    }
                    result.Description = "Success";
                    result.IsSuccessfull = true;
                    result.ResObj = clients;
                }
                else
                {
                    result.IsSuccessfull = false;
                    result.Description = "Client was not found";
                }
            }
            catch (Exception ex)
            {
                result.IsSuccessfull = false;
                result.Description = "Error: " + ex.Message;
            }
            return result;
        }
    }
}
