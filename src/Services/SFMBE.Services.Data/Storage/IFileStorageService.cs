namespace SFMBE.Services.Data.Storage
{
  using System.Threading.Tasks;

  public interface IFileStorageService
  {
    Task<string> EditFIle(byte[] content, string extension, string containerName, string fileRoute);

    Task DeleteFile(string fileRoute, string containerName);

    Task<string> SaveFile(byte[] content, string extension, string containerName);
  }
}
