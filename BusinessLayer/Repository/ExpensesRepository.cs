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


        public async Task<List<ExpensesModel>> GetExpensesAsync(Guid userId)
        {
            return await expensesDataLayerLogic.GetExpensesAsync(userId);
        }

        public async Task<ExpensesModel> CreateExpenseAsync(ExpensesModel newExpense)
        {
            return await expensesDataLayerLogic.CreateExpenseAsync(newExpense);
        }

        public async Task<ExpensesModel> GetExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            return await expensesDataLayerLogic.GetExpenseByIdAsync(expenseId, userId);
        }

        public async Task<Boolean> DeleteExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            return await expensesDataLayerLogic.DeleteExpenseByIdAsync(expenseId, userId);
        }

        public async Task<ExpensesModel> EditExpenseByIdAsync(Guid expenseId, ExpensesModel item)
        {
            return await expensesDataLayerLogic.EditExpenseByIdAsync(expenseId, item);
        }


        public float GetExpensesAmountAsync(Guid userId)
        {
            return  expensesDataLayerLogic.GetExpensesAmountAsync(userId);
        }

        





    }
}
