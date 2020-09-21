namespace SFMBE.Client.Infrastructure
{
  using Microsoft.JSInterop;
  using Newtonsoft.Json;
  using SFMBE.Client.Infrastructure.Common;
  using SFMBE.Client.Infrastructure.State;
  using SFMBE.Shared.Authentication.Commands;
  using System;
  using System.Collections.Generic;
  using System.Net.Http;
  using System.Net.Http.Headers;
  using System.Net.Http.Json;
  using System.Threading.Tasks;

  public class ApiClient : IApiClient
  {
    private readonly HttpClient httpClient;

    private readonly IApplicationState applicationState;
    private readonly IJSRuntime jsRuntime;

    public ApiClient(HttpClient httpClient, IApplicationState applicationState, IJSRuntime jsRuntime)
    {
      this.httpClient = httpClient;
      this.applicationState = applicationState;
      this.jsRuntime = jsRuntime;
    }

    public async Task<ApiResponse<RegisterParametersCommandResponse>> UserRegister(RegisterParametersCommand request)
      => await this.PostJson<RegisterParametersCommand, RegisterParametersCommandResponse>("api/Authorize/Register", request);

    public async Task<ApiResponse<LoginParametersCommandResponse>> UserLogin(LoginParametersCommand request)
    {
      try
      {
        var response = await this.httpClient.PostAsync(
                           "api/Authorize/Login",
                           new FormUrlEncodedContent(
                                       new List<KeyValuePair<string, string>>
                                       {
                                           new KeyValuePair<string, string>("email", request.Email),
                                           new KeyValuePair<string, string>("password", request.Password),
                                       }));

        var responseString = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
          return new ApiResponse<LoginParametersCommandResponse>(new ApiError("Server error " + (int)response.StatusCode, responseString));
        }

        var responseObject = JsonConvert.DeserializeObject<LoginParametersCommandResponse>(responseString);
        return new ApiResponse<LoginParametersCommandResponse>(responseObject);
      }
      catch (Exception ex)
      {
        return new ApiResponse<LoginParametersCommandResponse>(new ApiError("HTTP Client", ex.Message));
      }
    }

    private async Task<ApiResponse<TResponse>> PostJson<TRequest, TResponse>(string url, TRequest request)
    {
      await this.CheckApplicationState();

      try
      {
        var response = await this.httpClient.PostAsJsonAsync(url, request);
        var responseObject = await response.Content.ReadFromJsonAsync<ApiResponse<TResponse>>();
        return responseObject;
      }
      catch (Exception ex)
      {
        return new ApiResponse<TResponse>(new ApiError("HTTP Client", ex.Message));
      }
    }

    private async Task<ApiResponse<T>> GetJson<T>(string url)
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
        this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", this.applicationState.UserToken);
      }
    }
  }
}
