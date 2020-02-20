using System;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services;
using ExpensesTracker.ExceptionHandler;
using ExpensesTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedDTOs.DTOs;

namespace ExpensesTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userBusinessLogic;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;

        public UserController(IUserService userBusinessLogic, IExceptionHandler exceptionHandler, IMapper mapper, ILogger<UserController> logger)
        {
            this.userBusinessLogic = userBusinessLogic?? throw new ArgumentNullException(nameof(userBusinessLogic));
            this._exceptionHandler = exceptionHandler;
            this._mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Create new User 
        /// </summary>
        /// <param name="user">User Model that contains Username and Password  </param>
        /// <returns> Returns a Token</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateUser([FromBody]UserViewModel user)
        {
            try
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                UserDTO createdUserDTO = await userBusinessLogic.CreatedUserAsync(userDTO);
                UserViewModel userViewModel = _mapper.Map<UserViewModel>(createdUserDTO);
                _logger.LogInformation("Log message in the About() method");
                return Created("Successfully Created", userViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return _exceptionHandler.HandleError(ex.Message);
            }
        }

        /// <summary>
        /// Delete a user
        /// </summary>
        /// <returns>"Successfully Deleted</returns>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser([FromQuery]int userId)
        {
            try
            { 
                await userBusinessLogic.DeleteUserAsync(userId);
                return Ok("Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
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
                UserDTO authenticatedUser = await userBusinessLogic.AuthenticateUserAsync(userName, password);
                UserViewModel userViewModel = _mapper.Map<UserViewModel>(authenticatedUser);

                return Ok(userViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return _exceptionHandler.HandleError(ex.Message);

            }
        }
    }
}
