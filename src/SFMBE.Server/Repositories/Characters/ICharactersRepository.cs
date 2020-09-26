namespace SFMBE.Server.Repositories.Characters
{
  using System;
  using System.Threading.Tasks;
  using SFMBE.Shared.Characters.Queries;

  public interface ICharactersRepository
  {
    Task<int?> Create(string name);
    Task<(GetCharacterQueryResponse, string)> Get();
  }
}