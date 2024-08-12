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

    [HttpPost]
    public async Task<ActionResult<Player>> AddPlayer([FromBody] PlayerDto playerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var player = new Player
        {
            Name = playerDto.Name,
            Heart = playerDto.Heart,
            Level = playerDto.Level,
            Score = playerDto.Score
        };

        var createdPlayer = await _playersService.CreatePlayer(player);

        if (createdPlayer == null)
        {
            return Conflict($"A player '{player.Name}' already exists.");
        }

        return CreatedAtAction(nameof(FindPlayerById), new { id = createdPlayer.Id }, createdPlayer);
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