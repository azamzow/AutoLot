﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Models - CarDriverConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/01
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class CarDriverConfiguration : IEntityTypeConfiguration<CarDriver>
{
    public void Configure(EntityTypeBuilder<CarDriver> builder)
    {
        builder
            .Property(e => e.TimeStamp)
            .HasConversion<byte[]>();

        builder.HasQueryFilter(cd => cd.CarNavigation.IsDrivable);

        builder.ToTable( b => b.IsTemporal(t =>
        {
            t.HasPeriodEnd("ValidTo");
            t.HasPeriodStart("ValidFrom");
            t.UseHistoryTable("InventoryToDriversAudit");
        }));

    }
}