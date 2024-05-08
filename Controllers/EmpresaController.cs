using Delivery.Api.Entity;
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
public class EmpresaControllers : BaseController
{
    [HttpPost("Empresa/crear")]
    public async Task<ActionResult<Unit>> CrearEmpresa([FromBody] CrearEmpresaCommand command)
    {
        return Ok(await Mediator.Send(command));
    }


    [HttpGet("Empresa/obtener")]
    public async Task<ActionResult<IEnumerable<Empresa>>> ObtenerEmpresas()
    {
        return await Mediator.Send(new ConsultarEmpresasQuery());
    }
}