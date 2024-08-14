using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("monsters")]
[ApiController]
public class MonstersController : ControllerBase
{
    private readonly MonstersService _monstersService;

    public MonstersController(MonstersService monstersService)
    {
        _monstersService = monstersService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Monster>>> GetListMonsters()
    {
        var monsters = await _monstersService.GetListMonsters();
        return Ok(monsters);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Monster>> GetMonsterById(string id)
    {
        var monster = await _monstersService.GetMonsterById(id);

        if (monster == null)
        {
            return NotFound();
        }

        return Ok(monster);
    }

    [HttpPost]
    public async Task<ActionResult<Monster>> CreateMonster(Monster monster)
    {
        var createdMonster = await _monstersService.CreateMonster(monster);

        if (createdMonster == null)
        {
            return Conflict("A monster with the same name already exists.");
        }

        return CreatedAtRoute("GetMonster", new { id = createdMonster.Id }, createdMonster);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMonster(string id, [FromQuery] int damage)
    {
        var result = await _monstersService.DeleteMonsterById(id, damage);

        if (!result)
        {
            return NotFound("Monster not found or not enough damage to delete.");
        }

        return NoContent();
    }
}