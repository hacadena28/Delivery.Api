using Delivery.Api.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilio;

public record ConsultarDomicilioQuery() : IRequest<ActionResult<IEnumerable<Domicilio>>>;