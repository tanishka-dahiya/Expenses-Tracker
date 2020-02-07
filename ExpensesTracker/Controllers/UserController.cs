using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharedDTO.Models;

namespace ExpensesTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly IUserRepository UserBusinessLogic;



        public UserController(IUserRepository UserBusinessLogic)
        {
            this.UserBusinessLogic = UserBusinessLogic?? throw new ArgumentNullException(nameof(UserBusinessLogic));
        }



        // Create User-----> POST: api/User
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            try
            {
                if (user == null)
                {
                    return BadRequest("Enter valid User");
                }
                UserModel createdUser = await UserBusinessLogic.CreatedUserAsync(user);

                return Created("Successfully Created",createdUser.Token);
            }
            catch (Exception)
            {
                return NotFound("Internal Server Error");
            }

        }


        // Delete User-----> Delete: api/User
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
               Guid userId= Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
               Boolean isDeleted = await UserBusinessLogic.DeleteUserAsync(userId);
                if (!isDeleted)
                {
                    return NotFound("User Not Found");
                }
                return Ok("Successfully Deleted");
            }
            catch (Exception)
            {
                return NotFound("Internal Server Error");
            }

        }



        // Authenticate User-----> Get: api/User/authenticate
        [HttpGet("authenticate")]
        public async Task<IActionResult> AuthenticateUser(string userName, string password)
        {
            try
            {
                if (userName == null || password == null)
                {

                    return BadRequest("Enter valid Credentials");
                }
                var token = await UserBusinessLogic.AuthenticateUserAsync(userName, password);
                if (token == null)
                {
                    return BadRequest("Enter valid Credentials");
                }
                return Ok(token);
            }
            catch (Exception)
            {
                return NotFound("Internal Server Error");
            }

        }


    }
}
