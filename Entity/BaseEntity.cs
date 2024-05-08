using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Delivery.Api.Entity;

public class BaseEntity<T>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public virtual T Id { get; set; } = default!;
}