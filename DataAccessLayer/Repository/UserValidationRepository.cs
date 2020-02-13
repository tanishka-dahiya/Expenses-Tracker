using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserValidationRepository:IUserValidationRepository
    {

        private readonly ExpensesContext _context;
       


        public UserValidationRepository(ExpensesContext context)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            
        }

        //If user exists
        public async Task IsUserValid(Guid userId)
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
