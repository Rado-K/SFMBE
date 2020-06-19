namespace SFMBE.Server.Controllers.Base
{
  using MediatR;
  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.DependencyInjection;
  using SFMBE.Shared;
  using System.Collections.Generic;
  using System.Threading.Tasks;

  [ApiController]
  public class BaseEndpoint<TRequest, TResponse> : ControllerBase
      where TRequest : IRequest<TResponse>
  {
    private IMediator mediator;

    protected IMediator Mediator => this.mediator ??= this.HttpContext.RequestServices.GetService<IMediator>();

    protected virtual async Task<IActionResult> Send(TRequest request)
    {
      if (request is null || !this.ModelState.IsValid)
      {
        return this.ModelStateErrors<TResponse>() as IActionResult;
      }

      TResponse response = await this.Mediator.Send(request);

      return this.Ok(response);
    }

    protected ApiResponse<T> Error<T>(string item, string message)
    {
      return new ApiResponse<T>(new ApiError(item, message));
    }

    protected ApiResponse<T> ModelStateErrors<T>()
    {
      if (this.ModelState == null || this.ModelState.Count == 0)
      {
        return new ApiResponse<T>(new ApiError("Model", "Empty or null model."));
      }

      var errors = new List<ApiError>();
      foreach (var item in this.ModelState)
      {
        foreach (var error in item.Value.Errors)
        {
          errors.Add(new ApiError(item.Key, error.ErrorMessage));
        }
      }

      return new ApiResponse<T>(errors);
    }
  }
}
