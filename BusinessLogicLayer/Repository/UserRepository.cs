﻿
using BusinessLogicLayer.Services;
using DataAccessLayer.Services;
using Microsoft.EntityFrameworkCore;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository
{
    public class UserRepository:IUserRepository
    {

        private readonly IUserDataRepository UserDataLayerLogic;

        public UserRepository(IUserDataRepository userDataLayerLogic)
        {
            this.UserDataLayerLogic = userDataLayerLogic ?? throw new ArgumentNullException(nameof(userDataLayerLogic));
        }


        public async Task<UserModel> createdUserAsync(UserModel user)
        {
            return await UserDataLayerLogic.createdUserAsync(user);
        }
    }
}
