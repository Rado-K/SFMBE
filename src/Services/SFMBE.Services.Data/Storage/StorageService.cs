namespace SFMBE.Services.Data.Storage
{
  using System;
  using System.IO;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Hosting;
  using Microsoft.AspNetCore.Http;

  public class StorageService : IFileStorageService
  {
    private readonly IHostingEnvironment env;
    private readonly IHttpContextAccessor httpContextAccessor;

    public StorageService(IHostingEnvironment env, IHttpContextAccessor httpContextAccessor)
    {
      this.env = env;
      this.httpContextAccessor = httpContextAccessor;
    }

    public Task DeleteFile(string fileRoute, string containerName)
    {
      var fileName = Path.GetFileName(fileRoute);
      var fileDirectory = Path.Combine(env.WebRootPath, containerName, fileName);

      if (File.Exists(fileDirectory))
      {
        File.Delete(fileDirectory);
      }

      return Task.FromResult(0);
    }

    public async Task<string> EditFIle(byte[] content, string extension, string containerName, string fileRoute)
    {
      if (!string.IsNullOrEmpty(fileRoute))
      {
        await this.DeleteFile(fileRoute, containerName);
      }

      return await this.SaveFile(content, extension, containerName);
    }

    public async Task<string> SaveFile(byte[] content, string extension, string containerName)
    {
      var fileName = $"{Guid.NewGuid()}.{extension}";
      var folder = Path.Combine(env.WebRootPath, containerName);

      if (Directory.Exists(folder))
      {
        Directory.CreateDirectory(folder);
      }

      var savingPath = Path.Combine(folder, fileName);
      await File.WriteAllBytesAsync(savingPath, content);

      var currentUrl = $"{this.httpContextAccessor.HttpContext.Request.Scheme}://{this.httpContextAccessor.HttpContext.Request.Host}";
      var pathForDatabase = Path.Combine(currentUrl, containerName, fileName);

      return pathForDatabase;
    }
  }
}
