using System.Linq;
using FormGenerator.Model;
using Microsoft.EntityFrameworkCore;

namespace FormGenerator.Repository
{
    public class Repository<T> : IRepository<T> where T:Entity
    {
        private readonly FormGeneratorDbContext _context;
        private DbSet<T> DbSet { get; }

        public Repository(FormGeneratorDbContext context)
        {
            _context = context;
            DbSet = context.Set<T>();
        }
        public IQueryable<T> GetQueryable()
        {
            return DbSet;
        }

        public IQueryable<T> GetQueryableWithNoTracking()
        {
            return DbSet.AsNoTracking();
        }

        public void Insert(T obj)
        {
            var entry = DbSet.Add(obj);
            entry.State = EntityState.Added;
        }

        public void Update(T obj)
        {
            var entry = DbSet.Update(obj);
            entry.State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context?.SaveChanges();
        }
    }
}