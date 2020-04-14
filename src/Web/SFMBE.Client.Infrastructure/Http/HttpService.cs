namespace SFMBE.Client.Infrastructure.Http
{
  using System.Net.Http;
  using System.Text;
  using System.Text.Json;
  using System.Threading.Tasks;
  using SFMBE.Shared;

  public class HttpService : IHttpService
  {
    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions defaultJsonSerializerOptions;

    public HttpService(HttpClient httpClient)
    {
      this.httpClient = httpClient;
      this.defaultJsonSerializerOptions =
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
    }

    public async Task<ApiResponse<T>> Get<T>(string url)
    {
      var responseHTTP = await this.httpClient.GetAsync(url);

      if (responseHTTP.IsSuccessStatusCode)
      {
        var response = await this.Deserialize<ApiResponse<T>>(responseHTTP, this.defaultJsonSerializerOptions);
        return response;
      }

      return new ApiResponse<T>(new ApiError { Error = responseHTTP.StatusCode.ToString(), Item = await responseHTTP.Content.ReadAsStringAsync() });
    }

    public async Task<ApiResponse<object>> Post<T>(string url, T data)
    {
      var dataJson = JsonSerializer.Serialize(data);
      var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
      var response = await this.httpClient.PostAsync(url, stringContent);
      return new ApiResponse<object>(response);
    }

    public async Task<ApiResponse<TResponse>> Post<T, TResponse>(string url, T data)
      where T : HttpContent
    {
      var response = await this.httpClient.PostAsync(url, data);

      if (response.IsSuccessStatusCode)
      {
        var responseDeserialized = await this.Deserialize<ApiResponse<TResponse>>(response, this.defaultJsonSerializerOptions);
        return responseDeserialized;
      }

      return new ApiResponse<TResponse>(new ApiError { Error = response.StatusCode.ToString(), Item = await response.Content.ReadAsStringAsync() });
    }

    public async Task<ApiResponse<TResponse>> PostJson<T, TResponse>(string url, T data)
    {
      var dataJson = JsonSerializer.Serialize(data);
      var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");

      return await this.Post<StringContent, TResponse>(url, stringContent);
    }

    public async Task<ApiResponse<T>> Put<T>(string url, T data)
    {
      var dataJson = JsonSerializer.Serialize(data);
      var stringContent = new StringContent(dataJson, Encoding.UTF8, "application/json");
      var response = await this.httpClient.PutAsync(url, stringContent);
      if (response.IsSuccessStatusCode)
      {
        var responseDeserialized = await this.Deserialize<ApiResponse<T>>(response, this.defaultJsonSerializerOptions);
        return responseDeserialized;
      }

      return new ApiResponse<T>(new ApiError { Error = response.StatusCode.ToString(), Item = await response.Content.ReadAsStringAsync() });
    }

    public async Task<ApiResponse<object>> Delete(string url)
    {
      var responseHTTP = await this.httpClient.DeleteAsync(url);
      return new ApiResponse<object>(responseHTTP);
    }

    private async Task<T> Deserialize<T>(HttpResponseMessage httpResponse, JsonSerializerOptions options)
    {
      string responseString = await httpResponse.Content.ReadAsStringAsync();

      if (string.IsNullOrEmpty(responseString))
      {
        return default;
      }

      return JsonSerializer.Deserialize<T>(responseString, options);
    }
  }
}
