using AutoMapper;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ExpensesDataRepository : IExpensesDataService
    {
        private readonly ExpensesContext _context;
        private readonly IUserValidationService _userValidationRepository;



        public ExpensesDataRepository(ExpensesContext context, IUserValidationService userValidationRepository)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            _userValidationRepository = userValidationRepository;


        }

        //return all expenses list of a user
        public async Task<List<Expense>> GetExpensesAsync(int userId)
        {
            try
            {
                await _userValidationRepository.IsUserValid(userId);
                return await _context.Expenses.Where(s => s.UserId == userId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //create new expense
        public async Task<Expense> CreateExpenseAsync(Expense newExpense)
        {
            try
            {
                newExpense.Date =  DateTime.Today;
                await _userValidationRepository.IsUserValid(newExpense.UserId);
                _context.Expenses.Add(newExpense);
                await _context.SaveChangesAsync();
                return newExpense;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //return expense by its id
        public async Task<Expense> GetExpenseByIdAsync(int expenseId, int userId)
        {
            try
            {
                await _userValidationRepository.IsUserValid(userId);
                Expense expensesItem = await _context.Expenses.FirstOrDefaultAsync(s => s.UserId == userId && s.ExpensesId == expenseId);
                if (expensesItem == null)
                {
                    throw new Exception("Not found");
                }

                return expensesItem;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //delete a expense
        public async Task<Boolean> DeleteExpenseByIdAsync(int expenseId, int userId)
        {
            try
            {
                await _userValidationRepository.IsUserValid(userId);
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
        public async Task<Expense> EditExpenseByIdAsync(Expense item)
        {
            try
            {
                await _userValidationRepository.IsUserValid(item.UserId);
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        //return overall amount of expenses of a user
        public async Task<float> GetExpensesAmountAsync(int userId)
        {
            try
            {
                await _userValidationRepository.IsUserValid(userId);
                float expensesAmount = _context.Expenses.Where(s => s.UserId == userId).Sum(i => i.Price);

                return expensesAmount;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //delete all expenses of a user
        public async void DeleteAllExpensesOfUser(int userId)
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



    }
}
