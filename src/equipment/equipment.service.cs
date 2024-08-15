using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public class EquipmentService
{
    private readonly MongoDBContext _context;

    public EquipmentService(MongoDBContext context)
    {
        _context = context;
    }

    public async Task<List<Equipments>> GetListEquipments()
    {
        return await _context.Equipments.Find(eqiup => true).ToListAsync();
    }

    public async Task<Equipments> FindEquipmentById(string id)
    {
        return await _context.Equipments.Find(equip => equip.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Equipments> ChangeStatusEquipment(string playerId, string eqiupmentId, int status)
    {
        var foundEquipment = Builders<Equipments>.Filter.And(
            Builders<Equipments>.Filter.Eq(e => e.Id, eqiupmentId),
            Builders<Equipments>.Filter.Eq(e => e.PlayerId, playerId)
        );
        if(foundEquipment == null)
            throw new Exception("Can't find equipment");

        var update = Builders<Equipments>.Update.Set(equip => equip.Status, status);

        return await _context.Equipments.FindOneAndUpdateAsync(foundEquipment, update);
    }
}