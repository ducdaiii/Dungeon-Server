using System.ComponentModel.DataAnnotations;

public class CostumesDto
{
    [Range(0, 200, ErrorMessage = "Damage must be a positive value (1#100).")]
    public int Defense { get; set; } = 50;

    [Required(ErrorMessage = "Type is required.")]
    public string CostumeType  { get; set; } = null!;

    [Range(0, 200, ErrorMessage = "Damage must be a positive value (1#100).")]
    public int Heart { get; set; } = 30;
}