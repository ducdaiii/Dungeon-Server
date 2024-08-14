using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("player")]
public class PlayersController : ControllerBase
{
    private readonly PlayersService _playersService;

    public PlayersController(PlayersService playersService)
    {
        _playersService = playersService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetAll()
    {
        var players = await _playersService.GetListPlayers();
        return Ok(players);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> FindPlayerById(string id)
    {
        var player = await _playersService.GetPlayerById(id);

        if (player == null)
        {
            return NotFound();
        }

        return Ok(player);
    }
}