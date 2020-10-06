namespace SFMBE.Server.Repositories.Items
{
  using System.Threading.Tasks;
  using SFMBE.Shared.Items.Commands;
  
  public interface IItemsRepository
  {
    Task<int> Create(CreateItemCommand createItemCommand);
  }
}