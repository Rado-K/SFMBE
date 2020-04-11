namespace SFMBE.Server.Controllers
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Shared;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  [ApiController]
  [Route("api/[controller]")]
  public class BaseController : ControllerBase
  {
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