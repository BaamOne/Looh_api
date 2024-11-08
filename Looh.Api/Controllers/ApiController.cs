﻿using ErrorOr;
using Looh.Api.Common.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Looh.Api.Controllers
{

    [ApiController]
    [Authorize]
    public class ApiController: ControllerBase
    {

        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count == 0) {
                return Problem();
            }

            if (errors.All(e => e.Type == ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }

            HttpContext.Items[HttpContextItemKeys.Errors] = errors;

            var firstError = errors.First();

            return Problem(firstError);
        }

        private IActionResult Problem(Error error)
        {
            var statusCode = error.Type switch
            {
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            return Problem(statusCode: statusCode, title: error.Description);
        }

        private IActionResult ValidationProblem(List<Error> errors)
        {
            var modelEstateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelEstateDictionary.AddModelError(
                                        error.Code,
                                        error.Description);
            }

            return ValidationProblem(modelEstateDictionary);
        }
    }
}
