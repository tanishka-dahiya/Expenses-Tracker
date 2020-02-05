using DataAccessLayer.Contexts;
using DataAccessLayer.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly ExpensesContext _context;

        public UserRepository(ExpensesContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Entities.User>> getUsersAsync(Guid userId)
        {
            return await _context.Users.Include(b => b.UserId == userId).ToListAsync();
        }
    }
}
