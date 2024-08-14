using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Monster
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Health { get; set; }
    public int AttackPower { get; set; }
    public int Defense { get; set; }
    public string Description { get; set; } = "Level 1";
}
