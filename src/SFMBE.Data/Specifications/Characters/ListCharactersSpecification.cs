namespace SFMBE.Data.Specifications.Characters
{
  using Ardalis.Specification;
  using SFMBE.Data.Models;

  public sealed class ListCharactersSpecification : Specification<Character>
  {
    public ListCharactersSpecification(string parameter)
    {
      this.Query
        .Where(x => x.Name.StartsWith(parameter));
    }
  }
}
