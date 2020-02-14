using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Services;
using ExpensesTracker.ExceptionHandler;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedDTO.Models;

namespace ExpensesTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userBusinessLogic;
        private readonly IExceptionHandler _exceptionHandler;

        public UserController(IUserRepository userBusinessLogic, IExceptionHandler exceptionHandler)
        {
            this.userBusinessLogic = userBusinessLogic?? throw new ArgumentNullException(nameof(userBusinessLogic));
            this._exceptionHandler = exceptionHandler;
        }

        /// <summary>
        /// Create new User 
        /// </summary>
        /// <param name="user">User Model that contains Username and Password  </param>
        /// <returns> Returns a Token</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody]UserModel user)
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

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <returns>"Successfully Deleted</returns>
        ///  <response code="200">Successfully Deleted</response>
        ///  <response code="404">User Not Found</response>
        ///  
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

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

        /// <summary>
        /// Authenticate User with UserName and Password
        /// </summary>
        /// <param name="userName"> userName of the user</param>
        /// <param name="password">Password of that User</param>
        /// <returns>Token for Authentication further</returns>
        [HttpGet("authenticate")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AuthenticateUser([FromQuery]string userName, [FromQuery]string password)
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
