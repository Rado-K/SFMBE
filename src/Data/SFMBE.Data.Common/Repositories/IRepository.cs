﻿namespace SFMBE.Data.Common.Repositories
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Linq.Expressions;
  using System.Threading.Tasks;

  public interface IRepository<TEntity> : IDisposable
      where TEntity : class
  {
    IQueryable<TEntity> All();

    IQueryable<TEntity> AllAsNoTracking();

    Task AddAsync(TEntity entity);

    void Update(TEntity entity);

    void Delete(TEntity entity);

    Task<int> SaveChangesAsync();

    IQueryable<TEntity> GetWithProperties(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] properties);
  }
}
