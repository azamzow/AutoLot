// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor.Models - Car.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/11
// ==================================

namespace AutoLot.Blazor.Models.Entities;

public class Car : BaseEntity
{
    [Required, StringLength(50)] public string Color { get; set; }
    public string Price { get; set; }
    [DisplayName("Is Drivable")] public bool IsDrivable { get; set; } = true;
    public DateTime? DateBuilt { get; set; }
    public string Display { get; set; }

    [Required, StringLength(50), DisplayName("Pet Name")]
    public string PetName { get; set; }

    [Required, DisplayName("Make")] public int MakeId { get; set; }
    public Make MakeNavigation { get; set; }
    public string MakeName => MakeNavigation?.Name ?? "Unknown";

    public override string ToString()
    {
        return $"{PetName ?? "**No Name**"} is a {Color} {MakeNavigation?.Name} with ID {Id}.";
    }
}
