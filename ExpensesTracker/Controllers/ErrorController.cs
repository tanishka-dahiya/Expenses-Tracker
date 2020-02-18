
using System.Net;
using ExpensesTracker.ApiErrors;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Controllers
{
    [Route("/errors")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
            [Route("{code}")]
            [HttpGet]
            public IActionResult Error(int code)
            {
                HttpStatusCode parsedCode = (HttpStatusCode)code;
                ApiError error = new ApiError(code, parsedCode.ToString());

                return new ObjectResult(error);
            }
        
    }
}