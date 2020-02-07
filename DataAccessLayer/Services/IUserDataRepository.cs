using Microsoft.AspNetCore.Mvc;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Services
{
    public interface IUserDataRepository
    {
        Task<UserModel> CreatedUserAsync(UserModel user);
        string GenerateHashedPassword(string Password);
        string GenerateToken(Guid userId);
        Task<string> AuthenticateUserAsync(string username, string password);
        Task<Boolean> DeleteUserAsync(Guid userId);
    }
}
