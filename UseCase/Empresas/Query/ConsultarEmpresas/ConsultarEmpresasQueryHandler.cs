using AutoMapper;
using Delivery.Api.Entity;
using Delivery.Api.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.UseCase.Empresas.Query.ConsultarEmpresas;

public class
    ConsultarEmpresasQueryHandler : IRequestHandler<ConsultarEmpresasQuery, ActionResult<IEnumerable<Empresa>>>
{
    private readonly GenericRepository<Empresa> _empresaRepository;
    private readonly IMapper _mapper;

    public ConsultarEmpresasQueryHandler(GenericRepository<Empresa> empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<ActionResult<IEnumerable<Empresa>>> Handle(ConsultarEmpresasQuery request,
        CancellationToken cancellationToken)
    {
        IEnumerable<Empresa> empresas = await _empresaRepository.GetAllAsync();
       

        return new OkObjectResult(empresas);
    }
}