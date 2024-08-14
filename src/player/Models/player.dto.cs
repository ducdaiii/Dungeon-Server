using System.ComponentModel.DataAnnotations;

public class PlayerDto
{
    [Required(ErrorMessage = "Player name is required.")]
    [StringLength(100, ErrorMessage = "Player name can't be longer than 100 characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address format.")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password is required.")]
    [StringLength(10, ErrorMessage = "10 characters.")]
    public string PasswordHash { get; set; } = null!;

    [Range(6, 6, ErrorMessage = "Heart must be a positive value (#6).")]
    public double Heart { get; set; } = 6;

    [Range(1, 1, ErrorMessage = "Level must be a positive value (#1).")]
    public int Level { get; set; } = 1;

    [Required(ErrorMessage = "Attack Power is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Attack Power must be a non-negative number.")]
    public int AttackPower { get; set; } = 50;

    [Required(ErrorMessage = "Defense is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Defense must be a non-negative number.")]
    public int Defense { get; set; } = 50;

    [Range(0, 0, ErrorMessage = "Score must be a positive value (#0).")]
    public int Score { get; set; } = 0;
}