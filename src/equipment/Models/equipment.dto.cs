using System.ComponentModel.DataAnnotations;

public class EquipmentDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters.")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Type is required.")]
    public string TypeE { get; set; } = null!;
}