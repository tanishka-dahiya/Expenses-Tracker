using AutoMapper;
using DataAccessLayer.Entities;
using ExpensesTracker.ViewModels;
using SharedDTO.DTOs;

namespace ExpensesTracker.Mappers
{
      public class ExpesesProfile : Profile
      {
        public ExpesesProfile()
        {
            CreateMap<ExpensesViewModel, ExpensesDTO>();
            CreateMap<ExpensesDTO, ExpensesViewModel>();

        }
      }
    
}
