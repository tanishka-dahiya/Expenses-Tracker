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

        //return all expenses list of a user
        public async Task<List<ExpensesModel>> GetExpensesAsync(Guid userId)
        {
            var expensesList = await _context.Expenses.Where(s => s.UserId == userId).ToListAsync();
            return _mapper.Map<List<ExpensesModel>>(expensesList);

        }

        //create new expense
        public async Task<ExpensesModel> CreateExpenseAsync(ExpensesModel newExpense)
        {
            Expense createdExpese = _mapper.Map<Expense>(newExpense);
            _context.Expenses.Add(createdExpese);
            await _context.SaveChangesAsync();
            ExpensesModel savedExpense = _mapper.Map<ExpensesModel>(createdExpese);
            return savedExpense;

        }

        //return expense by its id
        public async Task<ExpensesModel> GetExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            Expense expensesItem = await _context.Expenses.FirstOrDefaultAsync(s => s.UserId == userId && s.ExpensesId == expenseId);
            ExpensesModel Item = _mapper.Map<ExpensesModel>(expensesItem);

            return Item;


        }

        //delete a expense
        public async Task<Boolean> DeleteExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            Expense item = await _context.Expenses.FirstOrDefaultAsync(s => s.UserId == userId && s.ExpensesId == expenseId);
            _context.Expenses.Remove(item);
            await _context.SaveChangesAsync();

            return true;

        }

        //edit a expense
        public async Task<ExpensesModel> EditExpenseByIdAsync(ExpensesModel item)
        {
            Expense expenseItem = _mapper.Map<Expense>(item);
            _context.Entry(expenseItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;


        }

        //return overall amount of expenses of a user
        public float GetExpensesAmountAsync(Guid userId)
        {
            float expensesAmount = _context.Expenses.Where(s => s.UserId == userId).Sum(i => i.Price);

            return expensesAmount;

        }


        //delete all expenses of a user
        public async void DeleteAllExpensesOfUser(Guid userId)
        {
            List<Expense> expensesItemList = _context.Expenses.Where(a => a.UserId == userId).ToList();
            foreach (Expense item in expensesItemList)
            {
                _context.Expenses.Remove(item);

            }
            await _context.SaveChangesAsync();
            return;

        }


    }
}
