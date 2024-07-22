namespace AutoLot.Services.ViewModels.Base;

public class AddToCartViewModelBase
{
    public int Id { get; set; }
    [Display(Name="Stock Quantity")]
    public int StockQuantity { get; set; }
    public int ItemId { get; set; }
}