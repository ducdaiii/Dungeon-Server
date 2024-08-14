using System.ComponentModel.DataAnnotations;

public class WeaponDto
{
    [Range(0, 200, ErrorMessage = "Damage must be a positive value (1#100).")]
    public int Damage { get; set; } = 30;

    [Required(ErrorMessage = "Type is required.")]
    public string WeaponType  { get; set; } = null!;
    public double RangeW { get; set; } = 5.5;
}