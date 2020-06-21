namespace SFMBE.Server.Controllers.Items.GetItems
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared;
  using SFMBE.Shared.Items.GetItems;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class GetItemsEndpoint : BaseEndpoint<GetItemsRequest, ApiResponse<GetItemsResponse>>
  {
    [HttpGet(GetItemsRequest.Route)]
    public async Task<IActionResult> Process([FromQuery] GetItemsRequest request)
      => await this.Send(request);
  }
}
