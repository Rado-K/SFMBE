namespace SFMBE.Client.Infrastructure
{
  using System.Threading.Tasks;
  using Microsoft.JSInterop;

  public static class JsInterop
  {
    public static async ValueTask<bool> SaveToken(this IJSRuntime runtime, string token)
      => await runtime.InvokeAsync<bool>("tokenManager.save", token);

    public static async ValueTask<string> ReadToken(this IJSRuntime runtime)
      => await runtime.InvokeAsync<string>("tokenManager.read");

    public static async ValueTask<bool> DeleteToken(this IJSRuntime runtime)
      => await runtime.InvokeAsync<bool>("tokenManager.delete");

    public static Task<bool> StorageSave(this IJSRuntime runtime, string key, string value)
      => runtime.InvokeAsync<bool>("storageManager.save", key, value).AsTask();

    public static Task<string> StorageRead(this IJSRuntime runtime, string key)
      => runtime.InvokeAsync<string>("storageManager.read", key).AsTask();

  }
}
