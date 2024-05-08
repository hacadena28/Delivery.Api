using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Delivery.Api.Entity;

public class Domicilio:BaseEntity<string>
{
    public Domicilio(string requestNombre, string requestDireccionOrigen, string requestDireccionDestino,
        double requestPrecio, string requestIdEmpresa, string requestFecha, string requestEstado)
    {
        Nombre = requestNombre;
        DireccionOrigen = requestDireccionOrigen;
        DireccionDestino = requestDireccionDestino;
        Precio = requestPrecio;
        IdEmpresa = requestIdEmpresa;
        Fecha = requestFecha;
        Estado = requestEstado;
    }

  
    public string Nombre { get; set; }
    public string DireccionOrigen { get; set; }
    public string DireccionDestino { get; set; }
    public double Precio { get; set; }
    public string IdEmpresa { get; set; }
    public string Fecha { get; set; }
    public string Estado { get; set; }
}