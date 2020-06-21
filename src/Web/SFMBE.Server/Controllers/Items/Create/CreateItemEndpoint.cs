namespace SFMBE.Server.Controllers.Items.Create
{
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared;
  using SFMBE.Shared.Items.Create;
  using System.Threading.Tasks;

  public class CreateItemEndpoint : BaseEndpoint<CreateItemRequest, ApiResponse<CreateItemResponse>>
  {
    [HttpPost(CreateItemRequest.Route)]
    public async Task<IActionResult> Process([FromBody] CreateItemRequest request)
      => await this.Send(request);
  }
}
