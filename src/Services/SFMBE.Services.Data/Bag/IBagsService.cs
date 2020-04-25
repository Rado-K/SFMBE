namespace SFMBE.Services.Data.Bag
{
  using SFMBE.Data.Models;
  using SFMBE.Shared.Bags;
  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;
  using System.Threading.Tasks;

  public interface IBagsService
  {
    Task<T> GetBag<T>(params Expression<Func<Bag, object>>[] properties);
  }
}