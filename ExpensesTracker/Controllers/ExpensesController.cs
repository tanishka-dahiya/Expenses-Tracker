using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharedDTO.Models;

namespace ExpensesTracker.Controllers
{
    [Route("user/Expenses")]
    [Authorize]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesRepository expensesBusinessLogic;

        public ExpensesController(IExpensesRepository expensesBusinessLogic)
        {
            this.expensesBusinessLogic = expensesBusinessLogic ?? throw new ArgumentNullException(nameof(expensesBusinessLogic));
        }

        // get all expenses of a user :----->GET: /user/Expenses
        [HttpGet]
        public async Task<IActionResult> GetExpenses()
        {
            try
            {
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                IEnumerable<ExpensesModel> expensesList= await expensesBusinessLogic.GetExpensesAsync(userId);
                return Ok(expensesList);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // create new expense of a user :----->POST: /user/Expenses
        [HttpPost]
        public async Task<IActionResult> CreateExpense(ExpensesModel newExpense)
        {
            try
            {
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                newExpense.UserId = userId;
                ExpensesModel createdExpense= await expensesBusinessLogic.CreateExpenseAsync(newExpense);

                return CreatedAtAction("GetExpenseById", new { expenseId = createdExpense.ExpensesId }, createdExpense);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // get expense by id :----->GET: /user/Expenses/{expenseId}
        [HttpGet("{expenseId}")]
        public async Task<IActionResult> GetExpenseById(Guid expenseId)
        {
            try
            {
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                ExpensesModel expenseItem = await expensesBusinessLogic.GetExpenseByIdAsync(expenseId, userId);
                return Ok(expenseItem);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        // Delete expense by id :----->DELETE: /user/Expenses/{expenseId}
        [HttpDelete("{expenseId}")]
        public async Task<IActionResult> DeleteExpenseById(Guid expenseId)
        {
            try
            {
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                Boolean isDeleted = await expensesBusinessLogic.DeleteExpenseByIdAsync(expenseId, userId);
                return Ok("Successfully Deleted");
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        // Edit expense by id :----->PUT: /user/Expenses/expenseId
        [HttpPut("expenseId")]
        public async Task<IActionResult> EditExpenseById(ExpensesModel item)
        {
            try
            {
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                item.UserId = userId;
                ExpensesModel expenseItem = await expensesBusinessLogic.EditExpenseByIdAsync( item);
                return Ok(expenseItem);
            }
            catch (Exception)
            {
                return Unauthorized();
            }
        }

        // Get expenses Amount by id :----->GET/user/Expenses/amount
        [HttpGet("amount")]
        public IActionResult GetExpensesAmount()
        {
            try
            {
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                var amount =  expensesBusinessLogic.GetExpensesAmountAsync( userId);
                return Ok(amount);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }


    }
}
