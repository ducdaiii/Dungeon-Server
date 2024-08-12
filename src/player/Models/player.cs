using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Player
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public double? Heart { get; set; } 
    public int? Level { get; set; }
    public int? Score { get; set; }
}