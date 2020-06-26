namespace SFMBE.Data.Configurations
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using SFMBE.Data.Models;

  public class VendorConfiguration : IEntityTypeConfiguration<Vendor>
  {
    public void Configure(EntityTypeBuilder<Vendor> builder)
    {
      builder
        .HasKey(x => x.Id);
    }
  }
}
