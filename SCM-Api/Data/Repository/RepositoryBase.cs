using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T>, IAsyncDisposable
        where T : class
    {
        protected RepositoryBase(DbContext context)
        {
            Context = context;
        }

        private DbContext Context { get; }

        public async Task<bool> Exists(Expression<Func<T, bool>> expression) =>
            await this.Context.Set<T>().AsNoTracking().Where(expression).AnyAsync();

        public IQueryable<T> Find() =>
            this.Context.Set<T>();

        public IQueryable<T> Find(Expression<Func<T, bool>> expression) =>
            this.Context.Set<T>().AsNoTracking().Where(expression);

        public void CreateEntity(T entity) =>
            this.Context.Set<T>().Add(entity);

        public void CreateMultipleEntity(List<T> entity) =>
            this.Context.Set<T>().AddRange(entity);

        public void UpdateEntity(T entity)
        {
            this.Context.Entry(entity).State = EntityState.Detached;
            this.Context.Set<T>().Update(entity);
        }

        public void UpdateMultipleEntities(List<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Context.Set<T>().Attach(entity);
                this.Context.Entry(entity).State = EntityState.Modified;
            }
        }

        public void DeleteEntity(T entity) =>
            this.Context.Set<T>().Remove(entity);

        public void DeleteMultipleEntity(IEnumerable<T> entities) =>
            this.Context.Set<T>().RemoveRange(entities);

        public async Task SaveAsync() =>
            await this.Context.SaveChangesAsync().ConfigureAwait(false);

        public async Task<int> ExecuteSqlCommandAsync(FormattableString sql) =>
            await this.Context.Database.ExecuteSqlInterpolatedAsync(sql);

        public async Task<IEnumerable<TEntity>> ExecuteStoredProcedureListAsync<TEntity>(FormattableString sql)
            where TEntity : class
            => await this.Context.Set<TEntity>().FromSqlInterpolated(sql).AsNoTracking().ToListAsync();

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public async ValueTask DisposeAsync() =>
           await this.Context.DisposeAsync();
    }
}
