using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class WeaponsService
{
    private readonly MongoDBContext _context;

    public WeaponsService(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<List<Weapon>> GetListWeapons()
    {
        return await _context.Weapons.Find(weapon => true).ToListAsync();
    }

    public async Task<Weapon> GetWeaponById(string id)
    {
        return await _context.Weapons.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Weapon> CreateWeapon(Weapon weapon)
    {
        var existing = await _context.Weapons
            .Find(p => p.Name == weapon.Name)
            .FirstOrDefaultAsync();

        if (existing != null)
        {
            return null!; 
        }

        await _context.Weapons.InsertOneAsync(weapon);
        return weapon;
    }
}