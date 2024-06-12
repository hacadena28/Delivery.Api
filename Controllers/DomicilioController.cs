using Delivery.Api.Entity;
using Delivery.Api.UseCase.Domicilios.Command.AceptarDomicilio;
using Delivery.Api.UseCase.Domicilios.Command.CrearDomicilio;
using Delivery.Api.UseCase.Domicilios.Command.EnviarDomicilio;
using Delivery.Api.UseCase.Domicilios.Command.FinalizarDomicilio;
using Delivery.Api.UseCase.Domicilios.Command.ModificarDomicilio;
using Delivery.Api.UseCase.Domicilios.Command.RechazarDomicilio;
using Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilio;
using Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorCorreo;
using Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorDomiciliario;
using Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorId;
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

    [HttpPut("Domicilio/aceptar")]
    public async Task<ActionResult<Unit>> AceptarDomicilio([FromBody] AceptarDomicilioCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    // [HttpPut("Domicilio/enviar")]
    // public async Task<ActionResult<Unit>> EnviarDomicilio([FromBody] EnviarDomicilioCommand command)
    // {
    //     return Ok(await Mediator.Send(command));
    // }

    [HttpPut("Domicilio/finalizar")]
    public async Task<ActionResult<Unit>> FinalizarDomicilio([FromBody] FinalizarDomicilioCommand command)
    {
        return Ok(await Mediator.Send(command));
    }

    [HttpPut("Domicilio/rechazar")]
    public async Task<ActionResult<Unit>> RechazarDomicilio([FromBody] RechazarDomicilioCommand command)
    {
        return Ok(await Mediator.Send(command));
    }


    [HttpGet("Domicilio/obtener")]
    public async Task<ActionResult<IEnumerable<Domicilio>>> ObtenerDomicilio()
    {
        return await Mediator.Send(new ConsultarDomicilioQuery());
    }

    [HttpGet("Domicilio/obtener/{id}")]
    public async Task<ActionResult<Domicilio>> ObtenerDomicilioPorId(string id)
    {
        return await Mediator.Send(new ConsultarDomicilioPorIdQuery(id));
    }

    [HttpGet("Domicilio/correo/obtener/{correo}")]
    public async Task<ActionResult<IEnumerable<Domicilio>>> ObtenerDomicilioPorCorreo(string correo)
    {
        return await Mediator.Send(new ConsultarDomicilioPorCorreoQuery(correo));
    }

    [HttpGet("Domicilio/repartidor/obtener/{idRepartidor}")]
    public async Task<ActionResult<IEnumerable<Domicilio>>> ObtenerDomicilioPorRepartidor(string idRepartidor)
    {
        return await Mediator.Send(new ConsultarDomicilioPorDomiciliarioQuery(idRepartidor));
    }
}