namespace AutoLot.Models.Entities.Configuration;

public class MakeConfiguration : IEntityTypeConfiguration<Make>
{
    public void Configure(EntityTypeBuilder<Make> builder)
    {
        builder
            .Property(e => e.TimeStamp)
            .HasConversion<byte[]>();

        builder.ToTable( b => b.IsTemporal(t =>
        {
            t.HasPeriodEnd("ValidTo");
            t.HasPeriodStart("ValidFrom");
            t.UseHistoryTable("MakesAudit");
        }));

    }
}