namespace SFMBE.Client.Pages.Character
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.AspNetCore.Components;
  using SFMBE.Client.Respository.Gears;
  using SFMBE.Shared.Items;

  public partial class Item
  {
    [Parameter]
    public ItemResponseModel Model { get; set; }

    [Parameter]
    public string ClassName { get; set; }

    [CascadingParameter]
    public IGearsRepository GearsRepository { get; set; }

    private async Task Equip()
    {
      await this.GearsRepository.Equip(this.Model.Id);
    }
  }
}
