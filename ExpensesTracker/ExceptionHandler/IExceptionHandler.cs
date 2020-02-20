using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.ExceptionHandler
{
    public interface IExceptionHandler
    {
        IActionResult HandleError(string errorMessage);

    }
}
