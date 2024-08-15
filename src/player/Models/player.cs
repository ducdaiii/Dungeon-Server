using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Player
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public string PasswordHash { get; set; } = null!;
    public double? Heart { get; set; } = 200;
    public int? AttackPower { get; set; } = 50;
    public int? Defense { get; set; } = 50;
    public int? Level { get; set; } = 1;
    public int? Score { get; set; } = 0;
    public List<Equipments>? Equipments { get; set; }
    public List<Equipments>? Inventory { get; set; }
}