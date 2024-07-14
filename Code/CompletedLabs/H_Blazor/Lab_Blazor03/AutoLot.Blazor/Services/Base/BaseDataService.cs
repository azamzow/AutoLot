// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor - BaseDataService.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/07
// ==================================

namespace AutoLot.Blazor.Services.Base;

public class BaseDataService
{
    protected static List<Make> Makes =
    [
        new() { Id = 1, Name = "VW" },
        new() { Id = 2, Name = "Ford" },
        new() { Id = 3, Name = "Saab" },
        new() { Id = 4, Name = "Yugo" },
        new() { Id = 5, Name = "BMW" },
        new() { Id = 6, Name = "Pinto" }
    ];
    protected List<Car> CarList =
    [
        new()
        {
            Id = 1, MakeId = 1, Color = "Black", PetName = "Zippy", Price = "$45,000.00",
            MakeNavigation = Makes.First(m => m.Id == 1)
        },

        new()
        {
            Id = 2, MakeId = 2, Color = "Rust", PetName = "Rusty", Price = "$45,000.00",
            MakeNavigation = Makes.First(m => m.Id == 2)
        },

        new()
        {
            Id = 3, MakeId = 3, Color = "Black", PetName = "Mel", Price = "$45,000.00",
            MakeNavigation = Makes.First(m => m.Id == 3)
        },

        new()
        {
            Id = 4, MakeId = 4, Color = "Yellow", PetName = "Clunker", Price = "$45,000.00",
            MakeNavigation = Makes.First(m => m.Id == 4)
        },

        new()
        {
            Id = 5, MakeId = 5, Color = "Black", PetName = "Bimmer", Price = "$45,000.00",
            MakeNavigation = Makes.First(m => m.Id == 5)
        },

        new()
        {
            Id = 6, MakeId = 5, Color = "Green", PetName = "Hank", Price = "$45,000.00",
            MakeNavigation = Makes.First(m => m.Id == 5)
        },

        new()
        {
            Id = 7, MakeId = 5, Color = "Pink", PetName = "Pinky", Price = "$45,000.00",
            MakeNavigation = Makes.First(m => m.Id == 5)
        },

        new()
        {
            Id = 8, MakeId = 6, Color = "Black", PetName = "Pete", Price = "$45,000.00",
            MakeNavigation = Makes.First(m => m.Id == 6)
        },

        new()
        {
            Id = 9, MakeId = 4, Color = "Brown", PetName = "Brownie", Price = "$45,000.00",
            MakeNavigation = Makes.First(m => m.Id == 4)
        },

        new()
        {
            Id = 10, MakeId = 1, Color = "Rust", PetName = "Lemon", IsDrivable = false,
            Price = "$45,000.00", MakeNavigation = Makes.First(m => m.Id == 1)
        }

    ];

}