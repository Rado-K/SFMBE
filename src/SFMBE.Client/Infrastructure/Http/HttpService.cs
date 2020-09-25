namespace SFMBE.Client.Infrastructure.Http
{
  using System.Net.Http.Headers;
  using System.Net.Http.Json;
  using System.Net.Http;
  using System.Text.Json;
  using System.Text;
  using System.Threading.Tasks;
  using System;
  using Microsoft.JSInterop;
  using SFMBE.Client.Infrastructure.Common;

  public class HttpService : IHttpService
  {
    private readonly HttpClient httpClient;
    private readonly IJSRuntime jsRuntime;

    public HttpService(HttpClient httpClient, IJSRuntime jsRuntime)
    {
      this.httpClient = httpClient;
      this.jsRuntime = jsRuntime;
    }

    public async Task<ApiResponse<TResponse>> PostJson<TRequest, TResponse>(string url, TRequest request)
    {
      try
      {
        HttpResponseMessage response;
        if (request is HttpContent)
        {
          response = await this.httpClient.PostAsync(url, request as HttpContent);
        }
        else
        {
          var stringContent = this.CreateStringContent(request);
          response = await this.httpClient.PostAsync(url, stringContent);
        }
        return await this.CreateResponse<TResponse>(response);
      }
      catch (Exception ex)
      {
        return new ApiResponse<TResponse>(new ApiError("HTTP Client", ex.Message));
      }
    }

    public async Task<ApiResponse<TResponse>> PutJson<TResponse>(string url, TResponse request)
    {
      try
      {
        var stringContent = this.CreateStringContent(request);
        var response = await this.httpClient.PutAsync(url, stringContent);

        return await this.CreateResponse<TResponse>(response);
      }
      catch (Exception ex)
      {
        return new ApiResponse<TResponse>(new ApiError("HTTP Client", ex.Message));
      }
    }

    public async Task<ApiResponse<TResponse>> GetJson<TResponse>(string url)
    {
      try
      {
        var response = await this.httpClient.GetAsync(url);
        return await this.CreateResponse<TResponse>(response);
      }
      catch (Exception ex)
      {
        return new ApiResponse<TResponse>(new ApiError("HTTP Client", ex.Message));
      }
    }

    public void SetAuthorization(AuthenticationHeaderValue value) => this.httpClient.DefaultRequestHeaders.Authorization = value;

    private StringContent CreateStringContent<TRequest>(TRequest request)
    {
      var serialized = JsonSerializer.Serialize(request);
      var stringContent = new StringContent(serialized, Encoding.UTF8, "application/json");
      return stringContent;
    }

    private async Task<ApiResponse<TResponse>> CreateResponse<TResponse>(HttpResponseMessage response)
    {
      var responseObject = await response.Content.ReadFromJsonAsync<TResponse>();
      return responseObject.ToApiResponse();
    }
  }
}