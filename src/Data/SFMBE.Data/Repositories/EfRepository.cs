namespace SFMBE.Data.Repositories
{
  using Microsoft.EntityFrameworkCore;
  using SFMBE.Data.Common.Repositories;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Linq.Expressions;
  using System.Threading.Tasks;

  public class EfRepository<TEntity> : IRepository<TEntity>
      where TEntity : class
  {
    public EfRepository(ApplicationDbContext context)
    {
      this.Context = context ?? throw new ArgumentNullException(nameof(context));
      this.DbSet = this.Context.Set<TEntity>();
    }

    protected DbSet<TEntity> DbSet { get; set; }

    protected ApplicationDbContext Context { get; set; }

    public virtual IQueryable<TEntity> All() => this.DbSet;

    public virtual IQueryable<TEntity> AllAsNoTracking() => this.DbSet.AsNoTracking();

    public virtual Task AddAsync(TEntity entity) => this.DbSet.AddAsync(entity).AsTask();

    public virtual void Update(TEntity entity)
    {
      var entry = this.Context.Entry(entity);
      if (entry.State == EntityState.Detached)
      {
        this.DbSet.Attach(entity);
      }

      entry.State = EntityState.Modified;
    }

    public virtual IEnumerable<TEntity> GetWithProperties(
      Expression<Func<TEntity, bool>> where,
      params Expression<Func<TEntity, object>>[] properties)
    {
      if (where == null)
        throw new ArgumentNullException(nameof(where));
      if (properties == null)
        throw new ArgumentNullException(nameof(properties));

      var query = this.DbSet as IQueryable<TEntity>;

      query = properties
                 .Aggregate(query, (current, property) => current.Include(property));

      return query.AsNoTracking().Where(where).ToList();
    }

    public virtual void Delete(TEntity entity) => this.DbSet.Remove(entity);

    public Task<int> SaveChangesAsync() => this.Context.SaveChangesAsync();

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (disposing)
      {
        this.Context?.Dispose();
      }
    }
  }
}
