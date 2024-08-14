using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Equipments
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? Name { get; set; }
    public int? Status { get; set; }
    public string? Description { get; set; }
    public string TypeE { get; set;} = null!;
}