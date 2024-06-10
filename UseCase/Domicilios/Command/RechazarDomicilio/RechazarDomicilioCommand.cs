using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.RechazarDomicilio;

public record RechazarDomicilioCommand(string IdDomicilio) : IRequest<Unit>;