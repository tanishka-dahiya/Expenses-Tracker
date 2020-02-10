using Microsoft.AspNetCore.Mvc;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUserRepository
    {
        Task<UserModel> CreatedUserAsync(UserModel user);
        Task<string> AuthenticateUserAsync(string username, string password);
        Task<Boolean> DeleteUserAsync(Guid userId);
    }
}
