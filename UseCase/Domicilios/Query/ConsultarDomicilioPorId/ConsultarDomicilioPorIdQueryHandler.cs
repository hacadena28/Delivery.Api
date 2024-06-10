using Delivery.Api.Entity;
using Delivery.Api.Repository;
using Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorId;

public class
    ConsultarDomicilioPorIdQueryHandler : IRequestHandler<ConsultarDomicilioPorIdQuery,
    ActionResult<Domicilio>>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public ConsultarDomicilioPorIdQueryHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<ActionResult<Domicilio>> Handle(ConsultarDomicilioPorIdQuery request,
        CancellationToken cancellationToken)
    {
        Domicilio domicilio = await _domicilioRepository.GetByIdAsync(request.IdDomicilio);

        return new OkObjectResult(domicilio);
    }
}