using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.AceptarDomicilio;

public record AceptarDomicilioCommand(string IdDomicilio, string IdRepartidor) : IRequest<Unit>;