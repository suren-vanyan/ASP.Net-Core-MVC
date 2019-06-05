using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(long id);
        IEnumerable<T> GetAll();
        void Create(T newDataObject);
        void Update(T chnagedDataObject);
        void Delete(long id);

    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected EFDatabaseContext _databaseContext;

        public GenericRepository(EFDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public void Create(T newDataObject)
        {
            _databaseContext.Add<T>(newDataObject);
            _databaseContext.SaveChanges();
        }

        public void Delete(long id)
        {
            _databaseContext.Remove<T>(Get(id));
            _databaseContext.SaveChanges();

        }

        public virtual T Get(long id)
        {
            return _databaseContext.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            var result = _databaseContext.Set<T>().ToList();
            return result;
        }

        public void Update(T changedDataObject)
        {

            _databaseContext.Update<T>(changedDataObject);
            _databaseContext.SaveChanges();
        }
    }
}
