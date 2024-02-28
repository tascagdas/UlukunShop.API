using System.Linq.Expressions;

namespace UlukunShopAPI.Application.Repositories;

public interface IReadRepository<T>:IRepository<T> where T:class
{
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>>method);
    T GetSingle(Expression<Func<T, bool>> method);
    T GetById(string id);
}