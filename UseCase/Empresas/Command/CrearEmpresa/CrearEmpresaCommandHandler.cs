using AutoMapper;
using Delivery.Api.Entity;
using Delivery.Api.Repository;
using MediatR;

namespace Delivery.Api.UseCase.Empresas.Command.CrearEmpresa;

public class CrearEmpresaCommandHandler : IRequestHandler<CrearEmpresaCommand, Unit>
{
    private readonly GenericRepository<Empresa> _empresaRepository;
    private readonly IMapper _mapper;

    public CrearEmpresaCommandHandler(GenericRepository<Empresa> empresaRepository, IMapper mapper)
    {
        _empresaRepository = empresaRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CrearEmpresaCommand request, CancellationToken cancellationToken)
    {
        Empresa empresa = new(request.NombreEmpresa, request.Direccion, request.Descripcion, request.Ranking);

        await _empresaRepository.InsertAsync(empresa);
        return Unit.Value;
    }
}