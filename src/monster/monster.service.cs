using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class MonstersService
{
    private readonly MongoDBContext _context;

    public MonstersService(MongoDBContext context)
    {
        _context = context;
    }

    // Lấy danh sách tất cả các Monsters
    public async Task<List<Monster>> GetListMonsters()
    {
        return await _context.Monsters.Find(monster => true).ToListAsync();
    }

    // Lấy thông tin Monster theo ID
    public async Task<Monster> GetMonsterById(string id)
    {
        return await _context.Monsters.Find(m => m.Id == id).FirstOrDefaultAsync();
    }

    // Tạo mới một Monster
    public async Task<Monster> CreateMonster(Monster monster)
    {
        // Kiểm tra xem tên quái vật đã tồn tại chưa
        var existingMonster = await _context.Monsters
            .Find(m => m.Name == monster.Name)
            .FirstOrDefaultAsync();

        if (existingMonster != null)
        {
            return null!;
        }

        // Nếu tên chưa tồn tại, chèn quái vật mới
        await _context.Monsters.InsertOneAsync(monster);
        return monster;
    }

    // Tính damage nhận vào và sau đó xóa Monster
    public async Task<bool> DeleteMonsterById(string id, int damageReceived)
    {
        // Tìm kiếm Monster theo ID
        var monster = await _context.Monsters.Find(m => m.Id == id).FirstOrDefaultAsync();

        if (monster == null)
        {
            return false; // Monster không tồn tại
        }

        // Tính toán damage nhận vào
        int remainingHealth = monster.Health - damageReceived;

        if (remainingHealth <= 0)
        {
            // Nếu máu còn lại <= 0, xóa Monster
            var deleteResult = await _context.Monsters.DeleteOneAsync(m => m.Id == id);
            return deleteResult.DeletedCount > 0;
        }
        else
        {
            // Cập nhật lại máu nếu Monster chưa chết
            var update = Builders<Monster>.Update.Set(m => m.Health, remainingHealth);
            var updateResult = await _context.Monsters.UpdateOneAsync(m => m.Id == id, update);
            return updateResult.ModifiedCount > 0;
        }
    }
}
