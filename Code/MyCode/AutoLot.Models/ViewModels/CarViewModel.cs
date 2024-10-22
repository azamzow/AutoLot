﻿namespace AutoLot.Models.ViewModels;

[Keyless]
[EntityTypeConfiguration(typeof(CarViewModelConfiguration))]
public class CarViewModel
{
    public int Id { get; set; }
    public bool IsDrivable { get; set; }
    public DateTime? DateBuilt { get; set; }
    public string Price { get; set; }
    public int MakeId { get; set; }
    public string Color { get; set; } = string.Empty;
    public string PetName { get; set; } = string.Empty;
}