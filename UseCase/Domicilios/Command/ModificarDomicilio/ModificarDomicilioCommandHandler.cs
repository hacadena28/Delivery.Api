using Delivery.Api.Entity;
using Delivery.Api.Repository;
using Delivery.Api.UseCase.Domicilios.Command.CrearDomicilio;
using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.ModificarDomicilio;

public class ModificarDomicilioCommandHandler : IRequestHandler<ModificarDomicilioCommand, Unit>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public ModificarDomicilioCommandHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<Unit> Handle(ModificarDomicilioCommand request, CancellationToken cancellationToken)
    {
        var domicilios = await _domicilioRepository.GetAllAsync();

        var domicilio = domicilios.FirstOrDefault(x => x.Id == request.Id);
        domicilio!.IdRepartidor=request.IdRepartidor;
        domicilio!.Estado = request.Estado;
        if(request.Estado == "entregado")
            domicilio.FechaFinal = DateTime.UtcNow;
        await _domicilioRepository.UpdateAsync(request.Id, domicilio);
        return Unit.Value;
    }
}