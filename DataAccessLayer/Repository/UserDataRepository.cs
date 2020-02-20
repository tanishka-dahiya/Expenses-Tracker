using AutoMapper;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedDTO.Helpers;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserDataRepository : IUserDataService
    {
        private readonly ExpensesContext _context;
        private readonly IExpensesDataService _expesesDataRepository;
        private readonly IUserValidationService _userValidationRepository;



        public UserDataRepository(ExpensesContext context, IExpensesDataService expesesDataREpository, IUserValidationService userValidationRepository)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            _expesesDataRepository = expesesDataREpository;
            _userValidationRepository = userValidationRepository;
        }


        //create User
        public async Task<User> CreatedUserAsync(User user)
        {
            try
            {
                user.Password = GenerateHashedPassword(user.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //create Hashed password
        private string GenerateHashedPassword(string password)
        {
            try
            {
                MD5 md5Hash = MD5.Create();
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        



        //Authenticate  User
        public async Task<User> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                password = GenerateHashedPassword(password);
                User authenticatedUser = await _context.Users.FirstOrDefaultAsync(a => a.UserName == username && a.Password == password);
                if (authenticatedUser == null)
                {
                    throw new Exception("Not found");

                }
                
                return authenticatedUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Delete User
        public async Task<Boolean> DeleteUserAsync(int userId)
        {
            try
            {
                await _userValidationRepository.IsUserValid(userId);
                User authenticatedUser = await _context.Users.FindAsync(userId);

                _context.Users.Remove(authenticatedUser);
                await _context.SaveChangesAsync();
                _expesesDataRepository.DeleteAllExpensesOfUser(userId);


                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }


        }




    }
}
