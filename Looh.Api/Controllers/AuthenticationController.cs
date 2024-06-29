﻿using ErrorOr;
using Looh.Application.Authentication.Commands.Register;
using Looh.Application.Services.Authentication.Commands;
using Looh.Application.Services.Authentication.Common;
using Looh.Application.Services.Authentication.Queries;
using Looh.Contracts.Authentication;
using Looh.Domain.Common.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Looh.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async  Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

        return authResult.Match(
               authResult => Ok(MapAuthResult(authResult)),
               errors => Problem(errors)
            );

    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.Token);
    }

    [HttpPost("login")]
    public  IActionResult Login(LoginRequest request)
    {
        var authResult = _authenticationQueryService.Login(request.Email, request.Password);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials) {
            return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
        }

        return authResult.Match(
                          authResult => Ok(MapAuthResult(authResult)),
                                        errors => Problem(errors)
                                                   );
    }


}

