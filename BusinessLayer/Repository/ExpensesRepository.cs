using AutoMapper;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using SharedDTO.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class ExpensesRepository : IExpensesService
    {
        private readonly IExpensesDataService expensesDataLayerLogic;
        private readonly IMapper _mapper;


        public ExpensesRepository(IExpensesDataService expensesDataLayerLogic, IMapper mapper)
        {
            this.expensesDataLayerLogic = expensesDataLayerLogic ?? throw new ArgumentNullException(nameof(expensesDataLayerLogic));
            _mapper = mapper;
        }

        //get all expenses of a user
        public async Task<List<ExpensesDTO>> GetExpensesAsync(int userId)
        {
            try
            {
                List<Expense> expenseList=await expensesDataLayerLogic.GetExpensesAsync(userId);
                return _mapper.Map<List<ExpensesDTO>>(expenseList);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //create expense of a user
        public async Task<ExpensesDTO> CreateExpenseAsync(ExpensesDTO newExpense)
        {
            try
            {
                Expense expense = _mapper.Map<Expense>(newExpense);
                Expense newExpenseEntity= await expensesDataLayerLogic.CreateExpenseAsync(expense);
                return _mapper.Map<ExpensesDTO>(newExpenseEntity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //get expense by its id
        public async Task<ExpensesDTO> GetExpenseByIdAsync(int expenseId, int userId)
        {
            try
            {
                Expense newExpenseEntity = await expensesDataLayerLogic.GetExpenseByIdAsync(expenseId, userId);
                return _mapper.Map<ExpensesDTO>(newExpenseEntity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //delete a expense
        public async Task<Boolean> DeleteExpenseByIdAsync(int expenseId, int userId)
        {
            try
            {
                return await expensesDataLayerLogic.DeleteExpenseByIdAsync(expenseId, userId);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //edit a expense
        public async Task<ExpensesDTO> EditExpenseByIdAsync(ExpensesDTO item)
        {
            try
            {
                Expense expense = _mapper.Map<Expense>(item);
                Expense newExpenseEntity= await expensesDataLayerLogic.EditExpenseByIdAsync(expense);
                return _mapper.Map<ExpensesDTO>(newExpenseEntity);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //get total amount on expenses of a user
        public Task<float> GetExpensesAmountAsync(int userId)
        {
            try
            {
                return expensesDataLayerLogic.GetExpensesAmountAsync(userId);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
