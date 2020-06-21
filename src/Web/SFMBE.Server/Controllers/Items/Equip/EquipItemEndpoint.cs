namespace SFMBE.Server.Controllers.Items.Equip
{
  using MediatR;
  using Microsoft.AspNetCore.Mvc;
  using SFMBE.Server.Controllers.Base;
  using SFMBE.Shared.Items.Equip;
  using System.Threading.Tasks;

  public class EquipItemEndpoint : BaseEndpoint<EquipItemRequest, Unit>
  {
    [HttpPost(EquipItemRequest.Route)]
    public async Task<IActionResult> Process([FromBody] EquipItemRequest request)
      => await this.Send(request);
  }
}
