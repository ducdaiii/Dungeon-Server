using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] PlayerDto request)
    {
        var player = await _authService.RegisterAsync(request.Name, request.Email, request.PasswordHash);
        return Ok(player);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] Player request)
    {
        try
        {
            var token = await _authService.LoginAsync(request.Name, request.PasswordHash);
            return Ok(new { Token = token });
        }
        catch (Exception ex)
        {
            return Unauthorized(ex.Message);
        }
    }
}