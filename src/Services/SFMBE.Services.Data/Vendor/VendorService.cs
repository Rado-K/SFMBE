namespace SFMBE.Services.Data.Vendor
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Items;
  using SFMBE.Services.Mapping;
  using System.Data;
  using System.Linq;
  using System.Threading.Tasks;

  public class VendorService : IVendorService
  {
    private readonly IRepository<Vendor> vendorRepository;
    private readonly IItemsService itemsService;

    public VendorService(
      IRepository<Vendor> vendorRepository,
      IItemsService itemsService)
    {
      this.vendorRepository = vendorRepository;
      this.itemsService = itemsService;
    }

    public async Task<Vendor> GetVendorById(int vendorId)
    {
      var vendor = await this.vendorRepository
        .AllAsNoTracking()
        .Where(x => x.Id == vendorId)
        .FirstOrDefaultAsync();

      var items = await this.itemsService.GetItemsByVendorId(vendorId);

      vendor.Items = items;

      return vendor;
    }

    public async Task<T> GetVendorById<T>(int vendorId)
    {
      var vendor = await this.GetVendorById(vendorId);

      return vendor.To<T>();
    }
  }
}
