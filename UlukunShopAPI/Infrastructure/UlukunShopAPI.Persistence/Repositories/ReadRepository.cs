using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using UlukunShopAPI.Application.Repositories;
using UlukunShopAPI.Domain.Entities.Common;
using UlukunShopAPI.Persistence.Contexts;

namespace UlukunShopAPI.Persistence.Repositories;

public class ReadRepository<T>:IReadRepository<T> where T : BaseEntity
{
    private readonly UlukunAPIDbContext _context;
    public ReadRepository(UlukunAPIDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public IQueryable<T> GetAll()
        => Table;

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
        => Table.Where(method);

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
        =>await Table.FirstOrDefaultAsync(method);

    public async Task<T> GetByIdAsync(string id)
        =>await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
    
}