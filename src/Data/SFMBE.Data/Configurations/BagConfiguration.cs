namespace SFMBE.Data.Configurations
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using SFMBE.Data.Models;

  public class BagConfiguration : IEntityTypeConfiguration<Bag>
  {
    public void Configure(EntityTypeBuilder<Bag> builder)
    {
      builder
        .HasKey(x => x.Id);

      builder
        .HasMany(x => x.Items)
        .WithOne(x => x.Bag)
        .HasForeignKey(x => x.BagId)
        .OnDelete(DeleteBehavior.Cascade);

    }
  }
}
