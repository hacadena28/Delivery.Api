using Delivery.Api.Entity;
using Delivery.Api.UseCase.Domicilios.Command.CrearDomicilio;
using Delivery.Api.UseCase.Domicilios.Command.ModificarDomicilio;
using Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilio;
using Delivery.Api.UseCase.Empresas.Command.CrearEmpresa;
using Delivery.Api.UseCase.Empresas.Query.ConsultarEmpresas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers;

/// <summary>
/// Controller VersionInfo
/// </summary>
[ApiController]
[Produces("application/json")]
public class DomicilioControllers : BaseController
{
    [HttpPost("Domicilio/crear")]
    public async Task<ActionResult<Unit>> CrearDomicilio([FromBody] CrearDomicilioCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("Domicilio/modificar")]
    public async Task<ActionResult<Unit>> ModificarDomicilio([FromBody] ModificarDomicilioCommand command)
    {
        return Ok(await Mediator.Send(command));
    }


    [HttpGet("Domicilio/obtener")]
    public async Task<ActionResult<IEnumerable<Domicilio>>> ObtenerDomicilio()
    {
        return await Mediator.Send(new ConsultarDomicilioQuery());
    }
}