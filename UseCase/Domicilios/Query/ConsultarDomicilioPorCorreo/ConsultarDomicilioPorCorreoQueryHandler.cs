using Delivery.Api.Entity;
using Delivery.Api.Repository;
using Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Domicilios.Query.ConsultarDomicilioPorCorreo;

public class
    ConsultarDomicilioPorCorreoQueryHandler : IRequestHandler<ConsultarDomicilioPorCorreoQuery,
    ActionResult<IEnumerable<Domicilio>>>
{
    private readonly GenericRepository<Domicilio> _domicilioRepository;

    public ConsultarDomicilioPorCorreoQueryHandler(GenericRepository<Domicilio> domicilioRepository)
    {
        _domicilioRepository = domicilioRepository;
    }

    public async Task<ActionResult<IEnumerable<Domicilio>>> Handle(ConsultarDomicilioPorCorreoQuery request,
        CancellationToken cancellationToken)
    {
        IEnumerable<Domicilio> domicilios =
            await _domicilioRepository.FilterAsync(e => e.CorreoUsuario == request.CorreoUsuario);

        return new OkObjectResult(domicilios);
    }
}