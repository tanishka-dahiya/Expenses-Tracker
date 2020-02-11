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
    public class ExpensesRepository:IExpensesRepository
    {
        private readonly IExpensesDataRepository expensesDataLayerLogic;

        public ExpensesRepository(IExpensesDataRepository expensesDataLayerLogic)
        {
            this.expensesDataLayerLogic = expensesDataLayerLogic ?? throw new ArgumentNullException(nameof(expensesDataLayerLogic));
        }

        //get all expenses of a user
        public async Task<List<ExpensesModel>> GetExpensesAsync(Guid userId)
        {
            return await expensesDataLayerLogic.GetExpensesAsync(userId);
        }

        //create expense of a user
        public async Task<ExpensesModel> CreateExpenseAsync(ExpensesModel newExpense)
        {
            return await expensesDataLayerLogic.CreateExpenseAsync(newExpense);
        }
        
        //get expense by its id
        public async Task<ExpensesModel> GetExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            return await expensesDataLayerLogic.GetExpenseByIdAsync(expenseId, userId);
        }

        //delete a expense
        public async Task<Boolean> DeleteExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            return await expensesDataLayerLogic.DeleteExpenseByIdAsync(expenseId, userId);
        }

        //edit a expense
        public async Task<ExpensesModel> EditExpenseByIdAsync( ExpensesModel item)
        {
            return await expensesDataLayerLogic.EditExpenseByIdAsync( item);
        }

        //get total amount on expenses of a user
        public float GetExpensesAmountAsync(Guid userId)
        {
            return  expensesDataLayerLogic.GetExpensesAmountAsync(userId);
        }

      
    }
}
