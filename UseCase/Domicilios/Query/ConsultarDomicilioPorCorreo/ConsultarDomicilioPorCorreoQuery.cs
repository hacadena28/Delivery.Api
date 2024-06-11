using Delivery.Api.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorCorreo;

public record ConsultarDomicilioPorCorreoQuery(string CorreoUsuario) : IRequest<ActionResult<IEnumerable<Domicilio>>>;