namespace SFMBE.Services.Data.Vendor
{
  using SFMBE.Data.Models;
  using System.Threading.Tasks;

  public interface IVendorService
  {
    Task<T> GetVendorById<T>(int id);
    Task<Vendor> GetVendorById(int id);
  }
}
