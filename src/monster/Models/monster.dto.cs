using System.ComponentModel.DataAnnotations;

public class MonsterDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Type is required.")]
    [StringLength(50, ErrorMessage = "Type can't be longer than 50 characters.")]
    public string Type { get; set; } = null!;

    [Required(ErrorMessage = "Health is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Health must be a non-negative number.")]
    public int Health { get; set; }

    [Required(ErrorMessage = "Attack Power is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Attack Power must be a non-negative number.")]
    public int AttackPower { get; set; }

    [Required(ErrorMessage = "Defense is required.")]
    [Range(0, int.MaxValue, ErrorMessage = "Defense must be a non-negative number.")]
    public int Defense { get; set; }

    public string Description { get; set; } = "No description available.";
}
