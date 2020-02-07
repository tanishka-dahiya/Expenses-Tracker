using BusinessLayer.Services;
using DataAccessLayer.Contexts;
using DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Repository
{
    public class ExpensesRepository:IExpensesRepository
    {
        private readonly ExpensesContext _context;

        public ExpensesRepository(ExpensesContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        
    }
}
