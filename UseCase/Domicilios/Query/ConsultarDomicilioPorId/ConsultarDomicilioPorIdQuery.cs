using Delivery.Api.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorId;

public record ConsultarDomicilioPorIdQuery(string IdDomicilio) : IRequest<ActionResult<Domicilio>>;