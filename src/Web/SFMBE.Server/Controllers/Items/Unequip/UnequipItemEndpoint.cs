namespace SFMBE.Server.Controllers.Items.Unequip
{
  using MediatR;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared.Items.Unequip;
  using System.Threading.Tasks;

  public class UnequipItemEndpoint : BaseEndpoint<UnequipItemRequest, Unit>
  {
    [HttpPost(UnequipItemRequest.Route)]
    public async Task<IActionResult> Process([FromBody] UnequipItemRequest request)
      => await this.Send(request);
  }
}
