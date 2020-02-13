using ExpensesTracker.ApiErrors;
using ExpensesTracker.ExceptionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracker.NewFolder
{
    public class ExceptionFilter  : ControllerBase,IExceptionHandler
    {
        public IActionResult HandleError(string errorMessage)
        {
            if (errorMessage == "Not found")
            {
                return NotFound(new NotFoundError(errorMessage));

            }
            return StatusCode(StatusCodes.Status500InternalServerError, new InternalServerError(errorMessage));

        }
    }
}
