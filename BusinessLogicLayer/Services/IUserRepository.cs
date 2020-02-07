using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public interface IUserRepository
    {
        Task<UserModel> createdUserAsync(UserModel user);
    }
}
