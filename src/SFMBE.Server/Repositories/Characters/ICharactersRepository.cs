namespace SFMBE.Server.Repositories.Characters
{
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using SFMBE.Shared.Characters.Commands;
  using SFMBE.Shared.Characters.Queries;

  public interface ICharactersRepository
  {
    Task<int?> Create(string name);
    
    Task < (GetCharacterQueryResponse, string) > Get();

    Task<IEnumerable<ListCharactersQueryResponse>> GetList(string parameter);

    Task<UpdateCharacterCommand> Update(UpdateCharacterCommand updateCharacterCommand);
  }
}