using AutoMapper;
using DataAccessLayer.Entities;
using SharedDTO.DTOs;

namespace BusinessLayer.Mappers
{
    public class ExpesesProfile : Profile
      {
        public ExpesesProfile()
        {
            CreateMap<Expense, ExpensesDTO>();
            CreateMap<ExpensesDTO, Expense>();


        }
      }
    
}
