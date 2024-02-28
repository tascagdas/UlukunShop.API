using Microsoft.EntityFrameworkCore;

namespace UlukunShopAPI.Application.Repositories;

public interface IRepository<T> where T:class
{
    DbSet<T> Table { get; }
}