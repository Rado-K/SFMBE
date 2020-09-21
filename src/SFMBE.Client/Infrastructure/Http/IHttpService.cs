namespace SFMBE.Client.Infrastructure.Http
{
  using SFMBE.Client.Infrastructure.Common;
  using SFMBE.Shared;
  using System.Threading.Tasks;

  public interface IHttpService
  {
    Task<ApiResponse<TResponse>> PostJson<TRequest, TResponse>(string url, TRequest request);

    Task<ApiResponse<T>> GetJson<T>(string url);
  }
}
