using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEFCore.AutoMapperProfile
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Entities.Role, Role>();
        }
    }
}
