using Delivery.Api.Entity;
using Delivery.Api.Repository;
using Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorDomiciliario;

public class
    ConsultarDomicilioPorDomiciliarioQueryHandler : IRequestHandler<ConsultarDomicilioPorDomiciliarioQuery,
    ActionResult<IEnumerable<Domicilio>>>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public ConsultarDomicilioPorDomiciliarioQueryHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<ActionResult<IEnumerable<Domicilio>>> Handle(ConsultarDomicilioPorDomiciliarioQuery request,
        CancellationToken cancellationToken)
    {
        IEnumerable<Domicilio> domicilios =
            await _domicilioRepository.FilterAsync(x => x.IdRepartidor == request.IdRepartidor);

        return new OkObjectResult(domicilios);
    }
}