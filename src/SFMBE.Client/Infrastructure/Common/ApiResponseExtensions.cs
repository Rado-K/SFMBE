namespace SFMBE.Client.Infrastructure.Common
{
  public static class ApiResponseExtensions
  {
    public static ApiResponse<T> ToApiResponse<T>(this T data)
        => new ApiResponse<T>(data);
  }
}
