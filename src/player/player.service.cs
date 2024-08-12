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

    public async Task<Player> CreatePlayer(Player player)
    {
        // Kiểm tra xem tên người chơi đã tồn tại chưa
        var existingPlayer = await _context.Players
            .Find(p => p.Name == player.Name)
            .FirstOrDefaultAsync();

        if (existingPlayer != null)
        {
            return null!; 
        }

        // Nếu tên chưa tồn tại, chèn người chơi mới
        await _context.Players.InsertOneAsync(player);
        return player;
    }
}