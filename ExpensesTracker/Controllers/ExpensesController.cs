using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Services;
using ExpensesTracker.ExceptionHandler;
using ExpensesTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedDTO.DTOs;
using SharedDTOs.DTOs;


namespace ExpensesTracker.Controllers
{
    [Route("user/Expenses")]
    [Authorize]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesService expensesBusinessLogic;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly IMapper _mapper;
        private readonly Microsoft.Extensions.Logging.ILogger _logger;


        public ExpensesController(IExpensesService expensesBusinessLogic, IExceptionHandler exceptionHandler, IMapper mapper, ILogger<ExpensesController> logger)
        {
            this.expensesBusinessLogic = expensesBusinessLogic ?? throw new ArgumentNullException(nameof(expensesBusinessLogic));
            this._exceptionHandler = exceptionHandler;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Get all Expenses of a user
        /// </summary>
        /// <returns> list of ExpensesViewModel</returns>
        [HttpGet("expense")]
        public async Task<IActionResult> GetExpenses([FromQuery]int userId)
        {
            try
            {
                List<ExpensesDTO> expensesDTOList= await expensesBusinessLogic.GetExpensesAsync(userId);
                List<ExpensesViewModel> userViewModelList =_mapper.Map<List<ExpensesViewModel>>(expensesDTOList);
                

                return Ok(userViewModelList);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return _exceptionHandler.HandleError(ex.Message);
            }
        }

       /// <summary>
       /// create  new expense of a user
       /// </summary>
       /// <param name="userId">user Id of the user of type integer</param>
       /// <param name="newExpense">ExpesesViewModel</param>
       /// <returns>created Expense and Location where expense is Created</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public async Task<IActionResult> CreateExpense([FromQuery]int userId,[FromBody]ExpensesViewModel newExpense)
        {
            try
            {
                newExpense.UserId = userId;
                ExpensesDTO expensesDTO = _mapper.Map<ExpensesDTO>(newExpense);
                ExpensesDTO createdExpense = await expensesBusinessLogic.CreateExpenseAsync(expensesDTO);
                ExpensesViewModel expesesViewModel = _mapper.Map<ExpensesViewModel>(createdExpense);
                return CreatedAtAction("GetExpenseById", new { expenseId = expesesViewModel.ExpensesId }, expesesViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return _exceptionHandler.HandleError(ex.Message);
            }
        }

        /// <summary>
        /// get expense by its id
        /// </summary>
        /// <param name="expenseId"> expense id of typeinteger </param>
        /// <param name="userId">user id of type integer</param>
        /// <returns> expensesViewModel</returns>
        [HttpGet("{expenseId}")]
        public async Task<IActionResult> GetExpenseById([FromQuery]int expenseId, [FromQuery]int userId)
        {
            try
            {
                ExpensesDTO expenseItem = await expensesBusinessLogic.GetExpenseByIdAsync(expenseId, userId);
                ExpensesViewModel expesesViewModel = _mapper.Map<ExpensesViewModel>(expenseItem);

                return Ok(expesesViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return _exceptionHandler.HandleError(ex.Message);
            }
        }

        /// <summary>
        /// delete a expense by its Id
        /// </summary>
        /// <param name="expenseId"></param>
        /// <param name="userId"></param>
        /// <returns> message "Successfully Deleted"</returns>
        [HttpDelete("{expenseId}")]
        public async Task<IActionResult> DeleteExpenseById([FromQuery]int expenseId, [FromQuery]int userId)
        {
            try
            {
                Boolean isDeleted = await expensesBusinessLogic.DeleteExpenseByIdAsync(expenseId, userId);
                return Ok("Successfully Deleted");
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return _exceptionHandler.HandleError(ex.Message);
            }
        }

       /// <summary>
       /// Edit an expense by its Id
       /// </summary>
       /// <param name="userId"></param>
       /// <param name="item"></param>
       /// <returns>Edited Expense view Model</returns>
        [HttpPut("expenseId")]
        public async Task<IActionResult> EditExpenseById([FromQuery]int userId,[FromBody]ExpensesViewModel item)
        {
            try
            {
                item.UserId = userId;
                ExpensesDTO expesesDTO = _mapper.Map<ExpensesDTO>(item);
                ExpensesDTO expenseItem = await expensesBusinessLogic.EditExpenseByIdAsync(expesesDTO);
                ExpensesViewModel expesesViewModel = _mapper.Map<ExpensesViewModel>(expenseItem);

                return Ok(expesesViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return _exceptionHandler.HandleError(ex.Message);
            }
        }

        /// <summary>
        /// get total amount spend on Expenses of a user
        /// </summary>
        /// <param name="userId">int userId</param>
        /// <returns>amount of type float</returns>
        [HttpGet("amount")]
        public  async Task<IActionResult> GetExpensesAmount([FromQuery]int userId)
        {
            try
            {
                var amount =   await expensesBusinessLogic.GetExpensesAmountAsync( userId);
                return Ok(amount);
            }
            catch (Exception ex )
            {
                _logger.LogInformation(ex.Message);
                return _exceptionHandler.HandleError(ex.Message);
            }
        }

    }
}
