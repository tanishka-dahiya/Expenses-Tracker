using AutoMapper;
using DataAccessLayer.Entities;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Mappers
{
      public class ExpesesProfile : Profile
      {
        public ExpesesProfile()
        {
            CreateMap<Expense, ExpensesModel>();
            CreateMap<ExpensesModel, Expense>();


        }
      }
    
}
