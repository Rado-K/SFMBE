namespace SFMBE.Data.Repositories
{
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Ardalis.Specification;
  using Ardalis.Specification.EntityFrameworkCore;
  using Microsoft.EntityFrameworkCore;

  public class EfRepository<T> : IAsyncRepository<T> where T : class
  {
    private readonly ApplicationDbContext dbContext;

    public EfRepository(ApplicationDbContext dbContext)
    {
      this.dbContext = dbContext;
    }

    public async Task<T> GetByIdAsync(int id)
    {
      return await this.dbContext.Set<T>().FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
      return await this.dbContext.Set<T>().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
      var specificationResult = this.ApplySpecification(spec);
      return await specificationResult.ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
      var specificationResult = this.ApplySpecification(spec);
      return await specificationResult.CountAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
      await this.dbContext.Set<T>().AddAsync(entity);
      await this.dbContext.SaveChangesAsync();

      return entity;
    }

    public async Task UpdateAsync(T entity)
    {
      this.dbContext.Entry(entity).State = EntityState.Modified;
      await this.dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
      this.dbContext.Set<T>().Remove(entity);
      await this.dbContext.SaveChangesAsync();
    }

    public async Task<T> FirstAsync(ISpecification<T> spec)
    {
      var specificationResult = this.ApplySpecification(spec);
      return await specificationResult.FirstAsync();
    }

    public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
    {
      var specificationResult = this.ApplySpecification(spec);
      return await specificationResult.FirstOrDefaultAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
      var evaluator = new SpecificationEvaluator<T>();
      return evaluator.GetQuery(this.dbContext.Set<T>().AsQueryable(), spec);
    }
  }
}
