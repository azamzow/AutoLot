namespace AutoLot.Blazor.Models.Entities;
public class Make : BaseEntity
{
    [Required, StringLength(50)]
    public string Name { get; set; }
    public IEnumerable<Car> Cars { get; set; } = new List<Car>();
}