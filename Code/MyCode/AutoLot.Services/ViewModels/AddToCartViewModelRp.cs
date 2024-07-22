namespace AutoLot.Services.ViewModels;

public class AddToCartViewModelRp : AddToCartViewModelBase
{
    [Required]
    [MustBeGreaterThanZero]
    [MustNotBeGreaterThan(nameof(StockQuantity), prefix: "Entity")]
    public int Quantity { get; set; }
}