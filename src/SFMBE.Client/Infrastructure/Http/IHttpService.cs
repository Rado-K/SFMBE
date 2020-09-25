namespace SFMBE.Client.Infrastructure.Http
{
  using SFMBE.Client.Infrastructure.Common;
  using System.Net.Http.Headers;
  using System.Threading.Tasks;

  public interface IHttpService
  {
    Task<ApiResponse<TResponse>> PostJson<TRequest, TResponse>(string url, TRequest request);

    Task<ApiResponse<T>> GetJson<T>(string url);

    Task<ApiResponse<TResponse>> PutJson<TResponse>(string url, TResponse request);

    void SetAuthorization(AuthenticationHeaderValue value);
  }
}
