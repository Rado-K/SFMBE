namespace SFMBE.Data.Specifications
{
  using Ardalis.Specification;
  using SFMBE.Data.Models;

  public sealed class GetUserSpecification : Specification<ApplicationUser>
  {
    public GetUserSpecification(string name)
      : base()
    {
      this.Query
        .Where(x => x.UserName == name);
    }
  }
}
