using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SharedDTO.Models;

namespace DataAccessLayer.Services
{
    public interface IExpensesDataRepository
    {
        Task<List<ExpensesModel>> GetExpensesAsync(Guid userId);
        Task<ExpensesModel> CreateExpenseAsync(ExpensesModel newExpense);
        Task<ExpensesModel> GetExpenseByIdAsync(Guid expenseId, Guid userId);
        Task<Boolean> DeleteExpenseByIdAsync(Guid expenseId, Guid userId);
        Task<ExpensesModel> EditExpenseByIdAsync(Guid expenseId, ExpensesModel item);
        float GetExpensesAmountAsync(Guid userId);

    }
}
