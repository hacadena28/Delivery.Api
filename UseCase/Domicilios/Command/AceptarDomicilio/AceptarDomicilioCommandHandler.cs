using Delivery.Api.common.Enum;
using Delivery.Api.Entity;
using Delivery.Api.Repository;
using Delivery.Api.UseCase.Domicilios.Command.AceptarDomicilio;
using Delivery.Api.UseCase.Domicilios.Command.CrearDomicilio;
using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.ModificarDomicilio;

public class AceptarDomicilioCommandHandler : IRequestHandler<AceptarDomicilioCommand, Unit>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public AceptarDomicilioCommandHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<Unit> Handle(AceptarDomicilioCommand request, CancellationToken cancellationToken)
    {
        var domicilio = await _domicilioRepository.GetByIdAsync(request.IdDomicilio);

        domicilio!.IdRepartidor = request.IdRepartidor;
        domicilio!.Estado = DeliveryState.EnCurso;
        await _domicilioRepository.UpdateAsync(request.IdDomicilio, domicilio);

        return Unit.Value;
    }
}