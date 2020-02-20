using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IExpensesDataService
    {
        Task<List<Expense>> GetExpensesAsync(int userId);
        Task<Expense> CreateExpenseAsync(Expense newExpense);
        Task<Expense> GetExpenseByIdAsync(int expenseId, int userId);
        Task<Boolean> DeleteExpenseByIdAsync(int expenseId, int userId);
        Task<Expense> EditExpenseByIdAsync(Expense item);
        Task<float> GetExpensesAmountAsync(int userId);
        void DeleteAllExpensesOfUser(int userId);

    }
}
