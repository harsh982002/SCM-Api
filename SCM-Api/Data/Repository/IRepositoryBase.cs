using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IRepositoryBase<T>
        where T : class
    {
        Task<bool> Exists(Expression<Func<T, bool>> expression);

        IQueryable<T> Find();

        IQueryable<T> Find(Expression<Func<T, bool>> expression);

        void CreateEntity(T entity);

        void UpdateEntity(T entity);

        void UpdateMultipleEntities(List<T> entities);

        void DeleteEntity(T entity);

        void DeleteMultipleEntity(IEnumerable<T> entities);

        Task SaveAsync();

        Task<int> ExecuteSqlCommandAsync(FormattableString sql);

        Task<IEnumerable<TEntity>> ExecuteStoredProcedureListAsync<TEntity>(FormattableString sql)
            where TEntity : class;
    }
}
