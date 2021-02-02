using MyTestStore.BLL.DTOs;
using MyTestStore.DLL.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyTestStore.BLL.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Client, ClientInfoDTO>(); 
            CreateMap<Client, ClientWithBirth>();
        }
    }
}
