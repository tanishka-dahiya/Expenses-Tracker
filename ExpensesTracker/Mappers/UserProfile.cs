using AutoMapper;
using DataAccessLayer.Entities;
using ExpensesTracker.ViewModels;
using SharedDTOs.DTOs;

namespace ExpensesTracker.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
           
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserViewModel, UserDTO>();

        }
    }
}
