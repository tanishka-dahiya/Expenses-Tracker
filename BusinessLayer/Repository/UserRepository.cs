
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
        
        //create a user
        public async Task<UserModel> CreatedUserAsync(UserModel user)
        {
            return await UserDataLayerLogic.CreatedUserAsync(user);
        }

        //authenticate a user with username and password
        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            return await UserDataLayerLogic.AuthenticateUserAsync(username, password);
        }

        //delete a user 
        public async Task<Boolean> DeleteUserAsync(Guid userId)
        {
            return await UserDataLayerLogic.DeleteUserAsync(userId);
        }


        
    }
}
