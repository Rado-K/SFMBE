namespace SFMBE.Data.Configurations.Character
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using SFMBE.Data.Models;
  using System;
  using System.Collections.Generic;
  using System.Text;

  public class ItemConfiguration : IEntityTypeConfiguration<Item>
  {
    public void Configure(EntityTypeBuilder<Item> builder)
    {
      builder
        .HasKey(x => x.Id);

      builder
        .HasOne(he => he.Bag)
        .WithMany(i => i.Items)
        .HasForeignKey(he => he.BagId)
        .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
