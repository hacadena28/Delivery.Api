using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.EnviarDomicilio;

public record EnviarDomicilioCommand(string IdDomicilio) : IRequest<Unit>;