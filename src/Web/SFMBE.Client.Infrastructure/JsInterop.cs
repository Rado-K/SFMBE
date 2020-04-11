namespace SFMBE.Client.Infrastructure
{
  using System;
  using System.Threading.Tasks;

  using Microsoft.JSInterop;

  // Implemented in jsInterop.js
  public static class JsInterop
  {
    public static async ValueTask<bool> SaveToken(this IJSRuntime runtime, string token)
    {
      return await runtime.InvokeAsync<bool>("tokenManager.save", token);
    }

    public static async ValueTask<string> ReadToken(this IJSRuntime runtime)
    {
      return await runtime.InvokeAsync<string>("tokenManager.read");
    }

    public static async ValueTask<bool> DeleteToken(this IJSRuntime runtime)
    {
      return await runtime.InvokeAsync<bool>("tokenManager.delete");
    }

    public static async ValueTask<bool> StorageSave(this IJSRuntime runtime, string key, string value)
    {
      return await runtime.InvokeAsync<bool>("storageManager.save", key, value);
    }

    public static async ValueTask<string> StorageRead(this IJSRuntime runtime, string key)
    {
      return await runtime.InvokeAsync<string>("storageManager.read", key);
    }

    public static async ValueTask<bool> StorageDelete(this IJSRuntime runtime, string key)
    {
      return await runtime.InvokeAsync<bool>("storageManager.delete", key);
    }

    public static async ValueTask<string> GetElementValue(this IJSRuntime runtime, string id)
    {
      return await runtime.InvokeAsync<string>("htmlHelper.getElementValue", id);
    }
  }
}
