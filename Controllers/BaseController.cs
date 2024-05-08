using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers;

/// <summary>
/// Base controller class providing common functionality and response codes.
/// </summary>
/// <response code="200">OK</response>
/// <response code="400">Bad Request</response>
/// <response code="401">Unauthorized</response>
/// <response code="404">Not Found</response>
/// <response code="500">Internal Server Error</response>
[Produces("application/json")]
[ProducesResponseType(200)]
[ProducesResponseType(400)]
[ProducesResponseType(401)]
[ProducesResponseType(404)]
[ProducesResponseType(500)]
public class BaseController : ControllerBase
{
    private IMediator? _mediator;

    /// <summary>
    /// Gets the Mediator instance for handling commands and queries.
    /// </summary>
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>() ??
                                                  throw new InvalidOperationException("IMediator is not registered.");
}