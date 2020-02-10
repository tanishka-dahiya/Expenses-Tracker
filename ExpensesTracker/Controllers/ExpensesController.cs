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
    
    [Authorize]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpensesRepository expensesBusinessLogic;



        public ExpensesController(IExpensesRepository expensesBusinessLogic)
        {
            this.expensesBusinessLogic = expensesBusinessLogic ?? throw new ArgumentNullException(nameof(expensesBusinessLogic));
        }






        // get all expenses of a user :----->GET: api/user/Expenses
        [HttpGet("user/Expenses")]
        public async Task<IActionResult> GetExpenses()
        {
            try
            {
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                IEnumerable<ExpensesModel> expensesList= await expensesBusinessLogic.GetExpensesAsync(userId);
                
                if (expensesList==null)
                {
                    return NotFound("User Not Found");
                }
                return Ok(expensesList);
            }
            catch (Exception)
            {
                return NotFound("Internal Server Error");
            }
        }





        // create new expense of a user :----->POST: api/user/Expenses
        
        [HttpPost("user/Expenses")]
        public async Task<IActionResult> CreateExpense(ExpensesModel newExpense)
        {
            try
            {
                if (newExpense == null)
                {
                    return BadRequest("Enter valid Data");
                }
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                newExpense.UserId = userId;
                ExpensesModel createdExpense= await expensesBusinessLogic.CreateExpenseAsync(newExpense);

               return CreatedAtAction("GetExpenseById", new { id = createdExpense.ExpensesId }, createdExpense);
            }
            catch (Exception)
            {
                return NotFound("Internal Server Error");
            }
        }





        // get expense by id :----->POST: api/user/Expenses/{id}
        [HttpGet("user/Expenses/{expenseId}")]
        public async Task<IActionResult> GetExpenseById(Guid expenseId)
        {
            try
            {
                if (expenseId == null)
                {
                    return BadRequest("Enter valid expenseId");
                }
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                ExpensesModel expenseItem = await expensesBusinessLogic.GetExpenseByIdAsync(expenseId, userId);
                if (expenseItem == null)
                {
                    return BadRequest("User is not Valid");
                }
                return Ok(expenseItem);
            }
            catch (Exception)
            {
                return NotFound("Internal Server Error");
            }
        }


        // Delete expense by id :----->DELETE: api/user/Expenses/{id}
        [HttpGet("user/Expenses/{id}")]
        public async Task<IActionResult> DeleteExpenseById(Guid expenseId)
        {
            try
            {
                if (expenseId == null)
                {
                    return BadRequest("Enter valid expenseId");
                }
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                Boolean isDeleted = await expensesBusinessLogic.DeleteExpenseByIdAsync(expenseId, userId);
                if (!isDeleted)
                {
                    return BadRequest("User is not Valid");
                }
                return Ok("Successfully Deleted");
            }
            catch (Exception)
            {
                return NotFound("Internal Server Error");
            }
        }



        // Edit expense by id :----->PUT: api/user/Expenses/{id}
        [HttpPut("user/Expenses/{id}")]
        public async Task<IActionResult> EditExpenseById(Guid expenseId,ExpensesModel item)
        {
            try
            {
                if (expenseId == null||item==null)
                {
                    return BadRequest("Enter valid expenseId or item");
                }
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                if(userId!= item.UserId)
                {
                    return BadRequest("User is not Valid");
                }
                ExpensesModel expenseItem = await expensesBusinessLogic.EditExpenseByIdAsync(expenseId, item);
                if (expenseItem==null)
                {
                    return BadRequest("User is not Valid");
                }
                return Ok(expenseItem);
            }
            catch (Exception)
            {
                return NotFound("Internal Server Error");
            }
        }




        // Get expenses Amount by id :----->DELETE: api/user/Expenses/{id}
        [HttpGet("user/Expenses/{id}")]
        public IActionResult GetExpensesAmount()
        {
            try
            {
                Guid userId = Guid.Parse(this.User.FindFirst(ClaimTypes.Name).Value);
                var amount =  expensesBusinessLogic.GetExpensesAmountAsync( userId);
                if (amount==-1)
                {
                    return BadRequest("User is not Valid");
                }
                return Ok(amount);
            }
            catch (Exception)
            {
                return NotFound("Internal Server Error");
            }
        }


    }
}
