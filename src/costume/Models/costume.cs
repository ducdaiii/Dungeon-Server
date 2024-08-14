using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Costumes : Equipments
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Cid { get; set; }
    public int? Defense { get; set; }
    public int? Heart { get; set; }
    public string CostumeType { get; set; } = null!;
}