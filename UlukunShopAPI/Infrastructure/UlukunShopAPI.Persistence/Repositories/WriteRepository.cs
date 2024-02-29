using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using UlukunShopAPI.Application.Repositories;
using UlukunShopAPI.Domain.Entities.Common;
using UlukunShopAPI.Persistence.Contexts;

namespace UlukunShopAPI.Persistence.Repositories;

public class WriteRepository<T>:IWriteRepository<T> where T:BaseEntity
{
    readonly private UlukunAPIDbContext _context;

    public WriteRepository(UlukunAPIDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();
    public async Task<bool> AddAsync(T model)
    {
      EntityEntry<T> entityEntry= await Table.AddAsync(model);
      return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        await Table.AddRangeAsync(datas);
        return true;
    }

    public bool Remove(T model)
    {
        EntityEntry<T> entityEntry= Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool RemoveRange(List<T> datas)
    {
        Table.RemoveRange(datas);
        return true;
    }

    public async Task<bool> Remove(string id)
    {
       T model= await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
       return Remove(model);
    }

    public bool Update (T model)
    {
        EntityEntry entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public async Task<int> SaveAsync()
    
      => await  _context.SaveChangesAsync();
    
}