using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Weapon : Equipments
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Wid { get; set; }
    public int? Damage { get; set; }
    public double? RangeW { get; set; }
    public string WeaponType { get; set; } = null!;
}