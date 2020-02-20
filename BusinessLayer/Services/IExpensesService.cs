using SharedDTO.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IExpensesService
    {
        Task<List<ExpensesDTO>> GetExpensesAsync(int userId);
        Task<ExpensesDTO> CreateExpenseAsync(ExpensesDTO newExpense);
        Task<ExpensesDTO> GetExpenseByIdAsync(int expenseId, int userId);
        Task<Boolean> DeleteExpenseByIdAsync(int expenseId, int userId);
        Task<ExpensesDTO> EditExpenseByIdAsync( ExpensesDTO item);
        Task<float> GetExpensesAmountAsync(int userId);

    }
}
