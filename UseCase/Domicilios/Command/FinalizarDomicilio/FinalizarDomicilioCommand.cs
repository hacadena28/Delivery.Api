using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.FinalizarDomicilio;

public record FinalizarDomicilioCommand(string IdDomicilio) : IRequest<Unit>;