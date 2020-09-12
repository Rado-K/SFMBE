namespace SFMBE.Shared.Items.Commands
{
  public class CreateItemCommand
  {
    public string ItemType { get; set; }

    public int Level { get; set; }

    public int Stamina { get; set; }

    public int Strength { get; set; }

    public int Agility { get; set; }

    public int Intelligence { get; set; }

    public int? VendorId { get; set; }

    public int? CharacterId { get; set; }
  }
}
