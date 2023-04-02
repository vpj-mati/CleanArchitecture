using ProcesoAutonomo.ServiceA.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ProcesoAutonomo.ServiceA.WebApi.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}
