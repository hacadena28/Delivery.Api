using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Delivery.Api.Entity;

public class Empresa:BaseEntity<string>
{
    public Empresa(string requestNombreEmpresa, string requestDireccion, string requestDescripcion,
        double requestRanking)
    {
        NombreEmpresa = requestNombreEmpresa;
        Direccion = requestDireccion;
        Descripcion = requestDescripcion;
        Ranking = requestRanking;
    }

   

    public string NombreEmpresa { get; set; }
    public string Direccion { get; set; }
    public string Descripcion { get; set; }
    public double Ranking { get; set; }
    public double Precio { get; set; }
}