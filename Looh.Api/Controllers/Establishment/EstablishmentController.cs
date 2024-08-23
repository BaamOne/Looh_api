using Looh.Contracts.Establishment;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult> Register(EstablishmentRequest request)
    { 
        return Ok();
    }


}
