using Delivery.Api.common.Enum;
using Delivery.Api.Entity;
using Delivery.Api.Repository;
using Delivery.Api.UseCase.Domicilios.Command.EnviarDomicilio;
using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.FinalizarDomicilio;

public class FinalizarDomicilioCommandHandler : IRequestHandler<FinalizarDomicilioCommand, Unit>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public FinalizarDomicilioCommandHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<Unit> Handle(FinalizarDomicilioCommand request, CancellationToken cancellationToken)
    {
        var domicilio = await _domicilioRepository.GetByIdAsync(request.IdDomicilio);

        domicilio!.Estado = DeliveryState.Entregado;
        domicilio!.FechaFinal = DateTime.UtcNow;
        await _domicilioRepository.UpdateAsync(request.IdDomicilio, domicilio);

        return Unit.Value;
    }
}