﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Looh.Api.Controllers
{
    [Route("unhandled")]
    public class ErrorsControllers : ControllerBase
    {
        [HttpGet("error")]
        public IActionResult Error() {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;


            return Problem();
        } 

    }
}
