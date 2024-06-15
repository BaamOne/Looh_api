using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Looh.Api.Controllers
{
    public class ErrorsControllers : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            return Problem();
        } 

    }
}
