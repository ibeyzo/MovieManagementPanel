using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        T Get(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetList(Expression<Func<T, bool>>? predicate = null);

        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
