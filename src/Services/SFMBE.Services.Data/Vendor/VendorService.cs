namespace SFMBE.Services.Data.Vendor
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Mapping;
  using System.Linq;
  using System.Threading.Tasks;

  public class VendorService : IVendorService
  {
    private readonly IRepository<Vendor> vendorRepository;

    public VendorService(IRepository<Vendor> vendorRepository)
    {
      this.vendorRepository = vendorRepository;
    }

    public async Task<T> GetVendorById<T>(int id)
    {
      var vendor = await this.GetVendorById(id);

      return vendor.To<T>();
    }

    public async Task<Vendor> GetVendorById(int id)
    {
      var vendor = await this.vendorRepository
        .AllAsNoTracking()
        .Where(x => x.Id == id)
        .Include(x => x.Items)
        .FirstOrDefaultAsync();

      return vendor;
    }
  }
}
