using Amazon.Runtime.Internal;
using MediatR;

namespace Delivery.Api.UseCase.Domicilios.Command.CrearDomicilio;

public record CrearDomicilioCommand(
    string Nombre,
    string DireccionOrigen,
    string DireccionDestino,
    double Precio,
    string IdEmpresa,
    string Fecha,
    string Descripcion,
    string CorreoUsuario) : IRequest<Unit>;