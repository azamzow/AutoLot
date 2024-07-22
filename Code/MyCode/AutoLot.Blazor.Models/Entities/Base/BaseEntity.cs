namespace AutoLot.Blazor.Models.Entities.Base;
public abstract class BaseEntity
{
    public int Id { get; set; }
    public long TimeStamp { get; set; }
}