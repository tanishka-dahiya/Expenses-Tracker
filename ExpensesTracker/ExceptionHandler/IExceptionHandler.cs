using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpensesTracker.ExceptionHandler
{
    public interface IExceptionHandler
    {
        IActionResult HandleError(string errorMessage);

    }
}
