namespace SFMBE.Data.Seeding
{
  using Microsoft.Extensions.DependencyInjection;
  using SFMBE.Data.Models;
  using SFMBE.Services.Data.Items;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  internal class ItemSeeder : ISeeder
  {
    public Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider) => throw new NotImplementedException();
  }
}
