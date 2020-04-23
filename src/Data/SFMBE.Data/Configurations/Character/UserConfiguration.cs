namespace SFMBE.Data.Configurations.Character
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using SFMBE.Data.Models;
  using System;
  using System.Collections.Generic;
  using System.Text;

  public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
  {
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
      builder
          .HasKey(x => x.Id);

      builder
        .HasOne(e => e.Character)
        .WithOne(h => h.User)
        .HasForeignKey<Character>(h => h.UserId)
        .OnDelete(DeleteBehavior.SetNull);
    }
  }
}
