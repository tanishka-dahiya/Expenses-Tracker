using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IExpensesRepository
    {
        Task<List<ExpensesModel>> GetExpensesAsync(Guid userId);
        Task<ExpensesModel> CreateExpenseAsync(ExpensesModel newExpense);
        Task<ExpensesModel> GetExpenseByIdAsync(Guid expenseId, Guid userId);
        Task<Boolean> DeleteExpenseByIdAsync(Guid expenseId, Guid userId);
        Task<ExpensesModel> EditExpenseByIdAsync( ExpensesModel item);
        float GetExpensesAmountAsync(Guid userId);

    }
}
