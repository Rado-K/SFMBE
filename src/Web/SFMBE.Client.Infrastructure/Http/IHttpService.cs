namespace SFMBE.Client.Infrastructure.Http
{
  using System.Net.Http;
  using System.Threading.Tasks;
  using SFMBE.Shared;

  public interface IHttpService
  {
    Task<ApiResponse<T>> Get<T>(string url);

    Task<ApiResponse<object>> Post<T>(string url, T data);

    Task<ApiResponse<TResponse>> PostJson<T, TResponse>(string url, T data);

    //Task<ApiResponse<object>> Put<T>(string url,itemsdata);

    Task<ApiResponse<object>> Delete(string url);

    Task<ApiResponse<TResponse>> Post<T, TResponse>(string url, T data) where T : HttpContent;
    Task<ApiResponse<T>> Put<T>(string url, T data);
  }
}