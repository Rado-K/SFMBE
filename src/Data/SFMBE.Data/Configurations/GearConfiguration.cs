namespace SFMBE.Data.Configurations
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using SFMBE.Data.Models;

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
