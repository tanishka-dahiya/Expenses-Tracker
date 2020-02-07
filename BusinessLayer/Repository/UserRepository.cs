
using BusinessLayer.Services;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class UserRepository:IUserRepository
    {

        private readonly IUserDataRepository UserDataLayerLogic;

        public UserRepository(IUserDataRepository userDataLayerLogic)
        {
            this.UserDataLayerLogic = userDataLayerLogic ?? throw new ArgumentNullException(nameof(userDataLayerLogic));
        }


        public async Task<UserModel> CreatedUserAsync(UserModel user)
        {
            return await UserDataLayerLogic.CreatedUserAsync(user);
        }

        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            return await UserDataLayerLogic.AuthenticateUserAsync(username, password);
        }

        public async Task<Boolean> DeleteUserAsync(Guid userId)
        {
            return await UserDataLayerLogic.DeleteUserAsync(userId);
        }

        
    }
}
