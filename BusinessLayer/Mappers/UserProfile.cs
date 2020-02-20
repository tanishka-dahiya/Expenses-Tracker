using AutoMapper;
using DataAccessLayer.Entities;
using SharedDTOs.DTOs;

namespace BusinessLayer.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
           
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

        }
    }
}
