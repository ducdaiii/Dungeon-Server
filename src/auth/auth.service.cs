using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

public class AuthService
{
    private readonly IMongoCollection<Player> _players;
    private readonly IConfiguration _configuration;

    public AuthService(MongoDBContext dbContext, IConfiguration configuration)
    {
        _players = dbContext.Players;
        _configuration = configuration;
    }

    public async Task<Player?> RegisterAsync(string name, string email, string password)
    {
        var existingPlayer = await _players.Find(p => p.Email == email).FirstOrDefaultAsync();
        if (existingPlayer != null)
        {
            throw new Exception("Player with this email already exists.");
        }

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        var player = new Player
        {
            Name = name,
            Email = email,
            PasswordHash = hashedPassword,
        };

        await _players.InsertOneAsync(player);
        return player;
    }

    public async Task<object> LoginAsync(string name, string password)
    {
        var player = await _players.Find(p => p.Name == name).FirstOrDefaultAsync();
        if (player == null || !BCrypt.Net.BCrypt.Verify(password, player.PasswordHash))
        {
            throw new Exception("Invalid username or password.");
        }

        var token = GenerateJwtToken(player);
        return new
        {
            metadata = new
            {
                player = new
                {
                    _id = player.Id,
                    userName = player.Name,
                    password = player.PasswordHash
                },
                tokens = token
            }
        };
    }

    private string GenerateJwtToken(Player player)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, player.Id!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}