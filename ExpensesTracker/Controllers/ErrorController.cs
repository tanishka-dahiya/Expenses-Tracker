using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ExpensesTracker.ApiErrors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesTracker.Controllers
{
    [Route("/errors")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
            [Route("{code}")]
            public IActionResult Error(int code)
            {
                HttpStatusCode parsedCode = (HttpStatusCode)code;
                ApiError error = new ApiError(code, parsedCode.ToString());

                return new ObjectResult(error);
            }
        
    }
}