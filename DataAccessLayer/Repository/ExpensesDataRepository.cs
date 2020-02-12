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
            try
            {
               await IsUserValid(userId);
                var expensesList = await _context.Expenses.Where(s => s.UserId == userId).ToListAsync();
                return _mapper.Map<List<ExpensesModel>>(expensesList);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //create new expense
        public async Task<ExpensesModel> CreateExpenseAsync(ExpensesModel newExpense)
        {
            try
            {
                await IsUserValid(newExpense.UserId);
                Expense createdExpese = _mapper.Map<Expense>(newExpense);
                _context.Expenses.Add(createdExpese);
                await _context.SaveChangesAsync();
                ExpensesModel savedExpense = _mapper.Map<ExpensesModel>(createdExpese);
                return savedExpense;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //return expense by its id
        public async Task<ExpensesModel> GetExpenseByIdAsync(Guid expenseId, Guid userId)
        {
            try
            {
               await IsUserValid(userId);
                Expense expensesItem = await _context.Expenses.FirstOrDefaultAsync(s => s.UserId == userId && s.ExpensesId == expenseId);
                if (expensesItem == null)
                {
                    throw new Exception("Not found");
                }
                ExpensesModel Item = _mapper.Map<ExpensesModel>(expensesItem);

                return Item;
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
               await IsUserValid(userId);
               Expense item = await _context.Expenses.FirstOrDefaultAsync(s => s.UserId == userId && s.ExpensesId == expenseId);
                if (item == null)
                {
                    throw new Exception("Not found");
                }
               _context.Expenses.Remove(item);
                await _context.SaveChangesAsync();

                return true;
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
                await IsUserValid(item.UserId);
                Expense expenseItem = _mapper.Map<Expense>(item);
                _context.Entry(expenseItem).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //return overall amount of expenses of a user
        public async Task<float> GetExpensesAmountAsync(Guid userId)
        {
            try
            {
                 await IsUserValid(userId);
                float expensesAmount = _context.Expenses.Where(s => s.UserId == userId).Sum(i => i.Price);

                return expensesAmount;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //delete all expenses of a user
        public async void DeleteAllExpensesOfUser(Guid userId)
        {
            try
            {

                List<Expense> expensesItemList = _context.Expenses.Where(a => a.UserId == userId).ToList();
                if (expensesItemList == null)
                {
                    return;
                }
                foreach (Expense item in expensesItemList)
                {
                    _context.Expenses.Remove(item);

                }
                await _context.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
            //If user exists
            private async Task IsUserValid(Guid userId)
            {
                try
                {
                    User authenticatedUser = await _context.Users.FindAsync(userId);

                    if (authenticatedUser == null)
                    {
                        throw new Exception("Not found");
                    }
                    return;
                }
                catch (Exception ex)
                {
                throw ex;
                }

            }
        


    }
}
