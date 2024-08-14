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
}