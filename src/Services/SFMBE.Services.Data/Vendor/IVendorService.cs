namespace SFMBE.Services.Data.Vendor
{
  using System.Threading.Tasks;

  public interface IVendorService
  {
    Task<T> GetVendorById<T>(int id);
  }
}
