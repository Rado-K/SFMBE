namespace SFMBE.Server.Controllers.User.Get
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Data.Models;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared.User.Get;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class GetUserEndpoint : BaseEndpoint<GetUserRequest, ApplicationUser>
  {
    [HttpGet(GetUserRequest.Route)]
    public async Task<IActionResult> Process(GetUserRequest request)
      => await this.Send(request);
  }
}
