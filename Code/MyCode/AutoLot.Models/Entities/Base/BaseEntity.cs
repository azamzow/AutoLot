namespace AutoLot.Models.Entities.Base;

public abstract class BaseEntity
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Timestamp]
    public long TimeStamp { get; set; }
}