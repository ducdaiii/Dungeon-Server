using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Token
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string UserId { get; set; } = null!;
    public string TokenValue { get; set; } = null!;
    public DateTime Expiration { get; set; }
}