using SharedDTOs.DTOs;
using System;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IUserService
    {
        Task<UserDTO> CreatedUserAsync(UserDTO user);
        Task<UserDTO> AuthenticateUserAsync(string username, string password);
        Task<Boolean> DeleteUserAsync(int userId);
    }
}
