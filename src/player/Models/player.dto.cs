using System.ComponentModel.DataAnnotations;

public class PlayerDto
{
    [Required(ErrorMessage = "Player name is required.")]
    [StringLength(100, ErrorMessage = "Player name can't be longer than 100 characters.")]
    public string Name { get; set; } = null!;

    [Range(6, 6, ErrorMessage = "Heart must be a positive value (#6).")]
    public double Heart { get; set; } = 6;

    [Range(1, 1, ErrorMessage = "Level must be a positive value (#1).")]
    public int Level { get; set; } = 1;

    [Range(0, 0, ErrorMessage = "Score must be a positive value (#0).")]
    public int Score { get; set; } = 0;
}