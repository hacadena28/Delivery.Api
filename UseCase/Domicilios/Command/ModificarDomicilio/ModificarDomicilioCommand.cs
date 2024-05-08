using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.ModificarDomicilio;

public record ModificarDomicilioCommand(string Id, string Estado) : IRequest<Unit>;