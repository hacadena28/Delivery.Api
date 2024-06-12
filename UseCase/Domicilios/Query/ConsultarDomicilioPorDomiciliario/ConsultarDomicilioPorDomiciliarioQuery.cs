using Delivery.Api.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorDomiciliario;

public record ConsultarDomicilioPorDomiciliarioQuery(string IdRepartidor)
    : IRequest<ActionResult<IEnumerable<Domicilio>>>;