namespace SFMBE.Data.Configurations.Character
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using SFMBE.Data.Models;
  using System;
  using System.Collections.Generic;
  using System.Text;

  public class GearConfiguration : IEntityTypeConfiguration<Gear>
  {
    public void Configure(EntityTypeBuilder<Gear> builder)
    {
      builder
        .HasKey(x => x.Id);

      builder
        .HasMany(x => x.EquippedItems)
        .WithOne(x => x.Gear)
        .HasForeignKey(x => x.GearId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
