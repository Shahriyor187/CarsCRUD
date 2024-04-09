using MongoDB.Bson.Serialization.Attributes;

namespace CarsCRUD.DTOs;
public class BaseDto
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
}