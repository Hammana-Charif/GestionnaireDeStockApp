using Service.Data;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContextService dbContext = new DbContextService();

        public IEnumerable<T> GetAll()
        {
            return dbContext.GetConnection().Set<T>().ToList();
        }

        public T GetSingleById(int id)
        {
            return dbContext.GetConnection().Set<T>().Find(id);
        }

        public void Insert(T obj)
        {
            _ = dbContext.GetConnection().Set<T>().Add(obj);
        }

        public void Delete(T obj)
        {
            _ = dbContext.GetConnection().Set<T>().Remove(obj);
        }

        public void Save()
        {
            _ = dbContext.GetConnection().SaveChanges();
        }

        public void Update(T obj)
        {
            _ = dbContext.GetConnection().Set<T>().Update(obj);
        }
    }
}
