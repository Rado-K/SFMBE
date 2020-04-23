namespace SFMBE.Data.Configurations.Character
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using SFMBE.Data.Models;
  using System;

  public class CharacterConfiguration : IEntityTypeConfiguration<Character>
  {
    public void Configure(EntityTypeBuilder<Character> builder)
    {
      builder
        .HasKey(x => x.Id);
    }
  }
}
