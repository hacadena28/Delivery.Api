using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.ModificarDomicilio;

public record ModificarDomicilioCommand(string Id, string Estado,string IdRepartidor) : IRequest<Unit>;