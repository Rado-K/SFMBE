namespace SFMBE.Data.Models
{
  using System;
  using Microsoft.AspNetCore.Identity;
  using SFMBE.Data.Common.Models;

  public class ApplicationRole : IdentityRole<string>, IAuditInfo, IDeletableEntity
  {
    public ApplicationRole()
        : this(default)
    {
    }

    public ApplicationRole(string name)
        : base(name)
    {
      this.Id = Guid.NewGuid().ToString();
    }

    public DateTime CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime? DeletedOn { get; set; }
  }
}
