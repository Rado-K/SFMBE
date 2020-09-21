namespace SFMBE.Client.Infrastructure.Http
{
  using System.Net.Http.Json;
  using System.Net.Http;
  using System.Text.Json;
  using System.Text;
  using System.Threading.Tasks;
  using System;
  using SFMBE.Client.Infrastructure.Common;

  public class HttpService : IHttpService
  {
    private readonly HttpClient httpClient;

    public HttpService(HttpClient httpClient)
    {
      this.httpClient = httpClient;
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
      try
      {
        return await this.httpClient.GetFromJsonAsync<ApiResponse<T>>(url);
      }
      catch (Exception ex)
      {
        return new ApiResponse<T>(new ApiError("HTTP Client", ex.Message));
      }
    }
  }
}