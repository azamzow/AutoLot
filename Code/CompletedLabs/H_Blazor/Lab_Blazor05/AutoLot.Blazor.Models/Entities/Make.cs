// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor.Models - Make.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/07
// ==================================

namespace AutoLot.Blazor.Models.Entities;

public class Make : BaseEntity
{
    [Required, StringLength(50)]
    public string Name { get; set; }
    public IEnumerable<Car> Cars { get; set; } = new List<Car>();
}
