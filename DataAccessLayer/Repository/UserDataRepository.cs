﻿using AutoMapper;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedDTO.Helpers;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class UserDataRepository:IUserDataRepository
    {
        private readonly ExpensesContext _context;
        private readonly IMapper _mapper;
        private readonly AppSetting _appSettings;
        private readonly IExpensesDataRepository _expesesDataRepository;
        private readonly IUserValidationRepository _userValidationRepository;



        public UserDataRepository(ExpensesContext context, IMapper mapper, IOptions<AppSetting> appSettings, IExpensesDataRepository expesesDataREpository, IUserValidationRepository userValidationRepository)
        {
            this._context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _expesesDataRepository = expesesDataREpository;
            _userValidationRepository = userValidationRepository;
        }


        //create User
        public async Task<UserModel> CreatedUserAsync(UserModel user)
        {
            try
            {
                user.Password = GenerateHashedPassword(user.Password);
                User createdUser = _mapper.Map<User>(user);
                _context.Users.Add(createdUser);
                await _context.SaveChangesAsync();
                UserModel savedUser = _mapper.Map<UserModel>(createdUser);
                savedUser.Password = null;
                savedUser.Token = GenerateToken(createdUser.UserId);

                return savedUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        
        //create Hashed password
        private  string GenerateHashedPassword(string password)
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

          //Generate Token
        private string GenerateToken(Guid userId)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, userId.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(45),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string Token = tokenHandler.WriteToken(token);
                return Token;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        //Authenticate  User
        public async Task<string> AuthenticateUserAsync(string username, string password)
        {
            try { 
            password = GenerateHashedPassword(password);
            User authenticatedUser = await _context.Users.FirstOrDefaultAsync(a => a.UserName == username && a.Password == password);
            if (authenticatedUser == null)
            {
                    throw new Exception("Not found");

                }
            var token = GenerateToken(authenticatedUser.UserId);
            return token;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //Delete User
        public async Task<Boolean> DeleteUserAsync(Guid userId)
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
