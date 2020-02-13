using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Services;
using ExpensesTracker.ApiErrors;
using ExpensesTracker.ExceptionHandler;
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
        private readonly IUserRepository userBusinessLogic;
        private readonly IExceptionHandler _exceptionHandler;


        public UserController(IUserRepository userBusinessLogic, IExceptionHandler exceptionHandler)
        {
            this.userBusinessLogic = userBusinessLogic?? throw new ArgumentNullException(nameof(userBusinessLogic));

            this._exceptionHandler = exceptionHandler;
        }
        
        // Create User-----> POST: api/User
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            try
            {
                UserModel createdUser = await userBusinessLogic.CreatedUserAsync(user);

                return Created("Successfully Created", createdUser.Token);
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleError(ex.Message);
            }

        }
        
        // Delete User-----> DELETE: api/User
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser()
        {
            try
            {
                Guid userId= Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                await userBusinessLogic.DeleteUserAsync(userId);
                return Ok("Successfully Deleted");
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleError(ex.Message);
            }

        }

        // Authenticate User with username and password-----> GET: api/User/authenticate
        [HttpGet("authenticate")]
        public async Task<IActionResult> AuthenticateUser(string userName, string password)
        {
            try
            {
                string token = await userBusinessLogic.AuthenticateUserAsync(userName, password);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return _exceptionHandler.HandleError(ex.Message);

            }

        }

    }
}
