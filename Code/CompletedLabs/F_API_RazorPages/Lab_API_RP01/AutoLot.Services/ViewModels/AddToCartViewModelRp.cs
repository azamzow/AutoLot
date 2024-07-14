// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - AddToCartViewModelRp.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Services.ViewModels;

public class AddToCartViewModelRp : AddToCartViewModelBase
{
    [Required]
    [MustBeGreaterThanZero]
    [MustNotBeGreaterThan(nameof(StockQuantity), prefix: "Entity")]
    public int Quantity { get; set; }
}