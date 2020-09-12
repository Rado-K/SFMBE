namespace SFMBE.Data.Configurations
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using SFMBE.Data.Models;

  public class CharacterConfiguration : IEntityTypeConfiguration<Character>
  {
    public void Configure(EntityTypeBuilder<Character> builder)
    {
      builder
        .HasKey(x => x.Id);
    }
  }
}
