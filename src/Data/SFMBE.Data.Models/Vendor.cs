namespace SFMBE.Data.Models
{
  using SFMBE.Data.Common.Models;

  public class Vendor : BaseModel<int>
  {
    public string Name { get; set; }

    public int BagId { get; set; }
    public Bag Bag { get; set; }
  }
}
