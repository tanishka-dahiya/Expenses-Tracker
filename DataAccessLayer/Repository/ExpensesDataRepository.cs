using AutoMapper;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using Microsoft.EntityFrameworkCore;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ExpensesDataRepository : IExpensesDataRepository
    {
        private readonly ExpensesContext _context;
        private readonly IMapper _mapper;


        public ExpensesDataRepository(ExpensesContext context, IMapper mapper)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;

        }


        public async Task<User> IsUserExists(Guid userId)
        {
            User userExists = await _context.Users.FindAsync(userId);
            if (userExists == null)
            {
                return null;
            }
            return userExists;

        }


        public async Task<List<ExpensesModel>> GetExpensesAsync(Guid userId)
        {
            try
            {
                if (IsUserExists(userId) == null)
                {
                    return null;
                }
                var expensesList = await _context.Expenses.Where(s => s.UserId == userId).ToListAsync();

                return _mapper.Map<List<ExpensesModel>>(expensesList);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ExpensesModel> CreateExpenseAsync(ExpensesModel newExpense)
        {
            if (IsUserExists(newExpense.UserId) == null)
            {
                return null;
            }
            Expense createdExpese = _mapper.Map<Expense>(newExpense);

            _context.Expenses.Add(createdExpese);
            await _context.SaveChangesAsync();
            ExpensesModel savedExpense = _mapper.Map<ExpensesModel>(createdExpese);


            return savedExpense;

        }


        public async Task<ExpensesModel> GetExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            if (IsUserExists(userId) == null)
            {
                return null;
            }

            Expense expensesItem = await _context.Expenses.FirstOrDefaultAsync(s => s.UserId == userId && s.ExpensesId == expenseId);

            ExpensesModel Item = _mapper.Map<ExpensesModel>(expensesItem);

            return Item;


        }



        public async Task<Boolean> DeleteExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            if (IsUserExists(userId) == null)
            {
                return false;
            }
            Expense item = await _context.Expenses.FirstOrDefaultAsync(s => s.UserId == userId && s.ExpensesId == expenseId);
            _context.Expenses.Remove(item);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<ExpensesModel> EditExpenseByIdAsync(Guid expenseId, ExpensesModel item)
        {
            if (IsUserExists(item.UserId) == null || expenseId != item.ExpensesId)
            {
                return null;
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;


        }


        public float GetExpensesAmountAsync(Guid userId)
        {
            if (IsUserExists(userId) == null)
            {
                return -1;
            }
            float expensesAmount = _context.Expenses.Where(s => s.UserId == userId).Sum(i => i.Price);

            return expensesAmount;

        }


















    }
}
