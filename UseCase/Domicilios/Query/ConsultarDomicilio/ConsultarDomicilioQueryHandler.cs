using Delivery.Api.Entity;
using Delivery.Api.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilio;

public class
    ConsultarDomicilioQueryHandler : IRequestHandler<ConsultarDomicilioQuery, ActionResult<IEnumerable<Domicilio>>>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public ConsultarDomicilioQueryHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<ActionResult<IEnumerable<Domicilio>>> Handle(ConsultarDomicilioQuery request,
        CancellationToken cancellationToken)
    {
        IEnumerable<Domicilio> empresas = await _domicilioRepository.GetAllAsync();

        return new OkObjectResult(empresas);
    }
}