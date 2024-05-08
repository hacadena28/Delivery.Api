using MediatR;

namespace Delivery.Api.UseCase.Empresas.Command.CrearEmpresa;

public record CrearEmpresaCommand(
    string NombreEmpresa,
    string Direccion,
    string Descripcion,
    double Ranking,
    double Precio) : IRequest<Unit>;