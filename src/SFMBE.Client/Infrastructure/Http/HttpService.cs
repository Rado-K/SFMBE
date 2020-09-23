namespace SFMBE.Client.Infrastructure.Http
{
  using System.Net.Http.Json;
  using System.Net.Http;
  using System.Text.Json;
  using System.Text;
  using System.Threading.Tasks;
  using System;
  using SFMBE.Client.Infrastructure.Common;
  using SFMBE.Client.Infrastructure.State;
  using System.Net.Http.Headers;
  using Microsoft.JSInterop;

  public class HttpService : IHttpService
  {
    private readonly HttpClient httpClient;
    private readonly IApplicationState applicationState;
    private readonly IJSRuntime jsRuntime;

    public HttpService(HttpClient httpClient, IApplicationState applicationState, IJSRuntime jsRuntime)
    {
      this.httpClient = httpClient;
      this.applicationState = applicationState;
      this.jsRuntime = jsRuntime;
    }

    public async Task<ApiResponse<TResponse>> PostJson<TRequest, TResponse>(string url, TRequest request)
    {
      await this.CheckApplicationState();
      try
      {
        HttpResponseMessage response;
        if (request is HttpContent)
        {
          response = await this.httpClient.PostAsync(url, request as HttpContent);
        }
        else
        {
          var serialized = JsonSerializer.Serialize(request);
          var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
          response = await this.httpClient.PostAsync(url, stringContent);
        }
        var responseObject = await response.Content.ReadFromJsonAsync<TResponse>();
        return responseObject.ToApiResponse();
      }
      catch (Exception ex)
      {
        return new ApiResponse<TResponse>(new ApiError("HTTP Client", ex.Message));
      }
    }

    public async Task<ApiResponse<T>> GetJson<T>(string url)
    {
      await this.CheckApplicationState();
      try
      {
        return await this.httpClient.GetFromJsonAsync<ApiResponse<T>>(url);
      }
      catch (Exception ex)
      {
        return new ApiResponse<T>(new ApiError("HTTP Client", ex.Message));
      }
    }

    private async Task CheckApplicationState()
    {
      if (this.applicationState.IsLoggedIn)
      {
        this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.applicationState.UserToken);
      }
      else if (await this.jsRuntime.ReadToken() != null)
      {
        var token = await this.jsRuntime.ReadToken();
        this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      }
    }
  }
}