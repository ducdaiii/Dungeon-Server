using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class PlayersService
{
    private readonly MongoDBContext _context;

    public PlayersService(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<List<Player>> GetListPlayers()
    {
        return await _context.Players.Find(player => true).ToListAsync();
    }

    public async Task<Player> GetPlayerById(string id)
    {
        return await _context.Players.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Equipments>> GetEquipmentsUse()
    {
        return await _context.Equipments.Find(equipment => true).ToListAsync();
    }
}