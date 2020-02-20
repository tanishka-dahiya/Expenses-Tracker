using DataAccessLayer.Entities;
using System;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IUserDataService
    {
        Task<User> CreatedUserAsync(User user);
        Task<User> AuthenticateUserAsync(string username, string password);
        Task<Boolean> DeleteUserAsync(int userId);
       
    }
}
