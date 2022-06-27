using System.Linq.Expressions;

namespace HRMS.EFDb.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(long id);
        Task<T> GetAsync(long id);

        List<T> Get();
        Task<List<T>> GetAsync();

        List<T> Find(Expression<Func<T, bool>> predicate);

        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);

        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        AppDbContext Context { get; }
    }
}
