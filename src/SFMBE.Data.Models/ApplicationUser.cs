namespace SFMBE.Data.Models
{
  using System;
  using System.Collections.Generic;
  using System.ComponentModel.DataAnnotations;
  using Microsoft.AspNetCore.Identity;
  using SFMBE.Data.Common.Models;

  public class ApplicationUser : IdentityUser<string>, IAuditInfo, IDeletableEntity
  {
    public ApplicationUser()
    {
      this.Id = Guid.NewGuid().ToString();
      this.Roles = new HashSet<IdentityUserRole<string>>();
      this.Claims = new HashSet<IdentityUserClaim<string>>();
      this.Logins = new HashSet<IdentityUserLogin<string>>();
    }

    #region
    // Audit info
    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    // Deletable entity
    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }

    public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

    public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

    public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

    #endregion

    [Required]
    public int CharacterId { get; set; }

    public virtual Character Character { get; set; }
  }
}
