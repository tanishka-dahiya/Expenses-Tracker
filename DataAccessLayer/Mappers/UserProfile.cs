using AutoMapper;
using DataAccessLayer.Entities;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
           
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();

        }
    }
}
