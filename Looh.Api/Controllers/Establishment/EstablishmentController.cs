using Looh.Application.Authentication.Commands.Register;
using Looh.Contracts.Establishment;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ErrorOr;
using Looh.Application.Establishments.Common;

namespace Looh.Api.Controllers.Establishment;


[Route("establishment")]
public class EstablishmentController: ApiController
{
    private readonly ISender _mediator;

    private readonly IMapper _mapper;

    public EstablishmentController(IMediator mediator, IMapper mapper) 
    { 
        _mediator = mediator;
        _mapper = mapper;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(EstablishmentRegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        ErrorOr<EstablishmentResult> establishmentResult = await _mediator.Send(command);

        return establishmentResult.Match(
            establishmentResult => Ok(_mapper.Map<EstablishmentResult>(establishmentResult)),
            errors => Problem(errors)
        );

    }


}
