using Delivery.Api.common.Enum;
using Delivery.Api.Entity;
using Delivery.Api.Repository;
using Delivery.Api.UseCase.Domicilios.Command.FinalizarDomicilio;
using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.RechazarDomicilio;

public class RechazarDomicilioCommandHandler : IRequestHandler<RechazarDomicilioCommand, Unit>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public RechazarDomicilioCommandHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<Unit> Handle(RechazarDomicilioCommand request, CancellationToken cancellationToken)
    {
        var domicilio = await _domicilioRepository.GetByIdAsync(request.IdDomicilio);

        domicilio!.Estado = DeliveryState.Rechazado;
        await _domicilioRepository.UpdateAsync(request.IdDomicilio, domicilio);

        return Unit.Value;
    }
}