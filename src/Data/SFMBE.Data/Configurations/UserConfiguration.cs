namespace SFMBE.Data.Configurations
{
  using Microsoft.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore.Metadata.Builders;
  using SFMBE.Data.Models;

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
