namespace SFMBE.Data.Specifications.Characters
{
  using Ardalis.Specification;
  using SFMBE.Data.Models;

  public sealed class GetCharacterSpecification : Specification<Character>
  {
    public GetCharacterSpecification(string userId)
    {
      this.Query
        .Where(x => x.UserId == userId)
        .Include(x => x.User);

      this.Query
        .Include(x => x.Items);
    }
  }
}
