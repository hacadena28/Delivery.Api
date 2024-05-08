using Delivery.Api.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Empresas.Query.ConsultarEmpresas;

public record ConsultarEmpresasQuery() : IRequest<ActionResult<IEnumerable<Empresa>>>;