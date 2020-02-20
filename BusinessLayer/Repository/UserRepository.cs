
using AutoMapper;
using BusinessLayer.Services;
using DataAccessLayer.Entities;
using DataAccessLayer.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedDTO.Helpers;
using SharedDTOs.DTOs;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class UserRepository : IUserService
    {

        private readonly IUserDataService UserDataLayerLogic;
        private readonly IMapper _mapper;
        private readonly AppSetting _appSettings;



        public UserRepository(IUserDataService userDataLayerLogic, IMapper mapper, IOptions<AppSetting> appSettings)
        {
            UserDataLayerLogic = userDataLayerLogic ?? throw new ArgumentNullException(nameof(userDataLayerLogic));
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        //create a user
        public async Task<UserDTO> CreatedUserAsync(UserDTO user)
        {
            try
            {
                User userEntity = _mapper.Map<User>(user);
                User createdUser= await UserDataLayerLogic.CreatedUserAsync(userEntity);
                UserDTO createduserDTO = _mapper.Map<UserDTO>(createdUser);
                createduserDTO.Token = GenerateToken(createduserDTO.UserId);
                createduserDTO.Password = null;
                return createduserDTO;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //authenticate a user with username and password
        public async Task<UserDTO> AuthenticateUserAsync(string username, string password)
        {
            try
            {
                User authenticatedUserEntity= await UserDataLayerLogic.AuthenticateUserAsync(username, password);
                UserDTO createduserDTO = _mapper.Map<UserDTO>(authenticatedUserEntity);
                createduserDTO.Token = GenerateToken(createduserDTO.UserId);
                createduserDTO.Password = null;
                return createduserDTO;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //delete a user 
        public async Task<Boolean> DeleteUserAsync(int userId)
        {
            try
            {
                return await UserDataLayerLogic.DeleteUserAsync(userId);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Generate Token
        private string GenerateToken(int userId)
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



    }
}
