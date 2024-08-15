using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("equipments")]
public class EquipmentsController : ControllerBase
{
    private readonly EquipmentService _equipService;

    public EquipmentsController(EquipmentService equipmentService)
    {
        _equipService = equipmentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipments>>> GetAll()
    {
        var equip = await _equipService.GetListEquipments();
        return Ok(equip);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Equipments>> GetEquipmentById(string id)
    {
        var equip = await _equipService.FindEquipmentById(id);

        if (equip == null)
        {
            return NotFound();
        }

        return Ok(equip);
    }
}