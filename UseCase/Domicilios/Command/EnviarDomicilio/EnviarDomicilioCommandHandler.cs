using Delivery.Api.common.Enum;
using Delivery.Api.Entity;
using Delivery.Api.Repository;
using Delivery.Api.UseCase.Domicilios.Command.AceptarDomicilio;
using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.EnviarDomicilio;

public class EnviarDomicilioCommandHandler : IRequestHandler<EnviarDomicilioCommand, Unit>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public EnviarDomicilioCommandHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<Unit> Handle(EnviarDomicilioCommand request, CancellationToken cancellationToken)
    {
        var domicilio = await _domicilioRepository.GetByIdAsync(request.IdDomicilio);

        domicilio!.Estado = DeliveryState.EnCamino;
        await _domicilioRepository.UpdateAsync(request.IdDomicilio, domicilio);

        return Unit.Value;
    }
}