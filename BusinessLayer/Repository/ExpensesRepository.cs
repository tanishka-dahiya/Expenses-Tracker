using BusinessLayer.Services;
using DataAccessLayer.Contexts;
using DataAccessLayer.Services;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class ExpensesRepository : IExpensesRepository
    {
        private readonly IExpensesDataRepository expensesDataLayerLogic;

        public ExpensesRepository(IExpensesDataRepository expensesDataLayerLogic)
        {
            this.expensesDataLayerLogic = expensesDataLayerLogic ?? throw new ArgumentNullException(nameof(expensesDataLayerLogic));
        }

        //get all expenses of a user
        public async Task<List<ExpensesModel>> GetExpensesAsync(Guid userId)
        {
            try
            {
                return await expensesDataLayerLogic.GetExpensesAsync(userId);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //create expense of a user
        public async Task<ExpensesModel> CreateExpenseAsync(ExpensesModel newExpense)
        {
            try
            {
                return await expensesDataLayerLogic.CreateExpenseAsync(newExpense);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //get expense by its id
        public async Task<ExpensesModel> GetExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            try
            {
                return await expensesDataLayerLogic.GetExpenseByIdAsync(expenseId, userId);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //delete a expense
        public async Task<Boolean> DeleteExpenseByIdAsync(Guid expenseId, Guid userId)
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
        public async Task<ExpensesModel> EditExpenseByIdAsync(ExpensesModel item)
        {
            try
            {
                return await expensesDataLayerLogic.EditExpenseByIdAsync(item);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //get total amount on expenses of a user
        public Task<float> GetExpensesAmountAsync(Guid userId)
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
