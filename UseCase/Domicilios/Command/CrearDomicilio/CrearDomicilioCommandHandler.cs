using Delivery.Api.common.Enum;
using Delivery.Api.Entity;
using Delivery.Api.Repository;
using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.CrearDomicilio;

public class CrearDomicilioCommandHandler : IRequestHandler<CrearDomicilioCommand, Unit>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public CrearDomicilioCommandHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<Unit> Handle(CrearDomicilioCommand request, CancellationToken cancellationToken)
    {
        Domicilio domicilio = new(request.Nombre, request.DireccionOrigen, request.DireccionDestino, request.Precio,
            request.IdEmpresa, request.Fecha, DeliveryState.EnEspera, DateTime.UtcNow, null, null, request.Descripcion,
            request.CorreoUsuario);

        await _domicilioRepository.InsertAsync(domicilio);
        return Unit.Value;
    }
}