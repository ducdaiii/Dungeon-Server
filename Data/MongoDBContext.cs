using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDBContext
{
    private readonly IMongoDatabase _database;

    public MongoDBContext(IOptions<MongoDBSettings> settings)
    {
        if (settings == null || settings.Value == null)
        {
            throw new ArgumentNullException(nameof(settings), "MongoDB settings cannot be null");
        }

        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);

        // Optionally, check if the database is available
        try
        {
            // Use a specific result type for the ping command
            var command = new BsonDocument("ping", 1);
            var result = _database.RunCommand<BsonDocument>(command);
        }
        catch (Exception ex)
        {
            throw new Exception("Failed to connect to MongoDB", ex);
        }
    }

    public IMongoCollection<Player> Players => _database.GetCollection<Player>("players");
    public IMongoCollection<Weapon> Weapons => _database.GetCollection<Weapon>("weapons");
    public IMongoCollection<Equipments> Equipments => _database.GetCollection<Equipments>("equipments");
    public IMongoCollection<Monster> Monsters => _database.GetCollection<Monster>("monsters");
}