namespace SFMBE.Server.Repositories.Characters
{
  using System;
  using System.Threading.Tasks;

  public interface ICharactersRepository
  {
    Task<int?> Create(string name);
  }
}