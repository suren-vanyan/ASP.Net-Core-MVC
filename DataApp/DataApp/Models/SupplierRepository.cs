using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataApp.Models
{
    public interface ISupplierRepository
    {
        Supplier Get(long id);
        IEnumerable<Supplier> GetAll();
        void Create(Supplier newDataObject);
        void Update(Supplier changedDataObject);
        void Delete(long id);

    }
    public class SupplierRepository : ISupplierRepository
    {
        private EFDatabaseContext context;

        public SupplierRepository(EFDatabaseContext context)
        {
            this.context = context;
        }
        public void Create(Supplier newDataObject)
        {
            context.Add(newDataObject);
            context.SaveChanges();
        }

        public void Delete(long id)
        {
            context.Suppliers.Remove(Get(id));
            context.SaveChanges();
        }

        public Supplier Get(long id)
        {
            return context.Suppliers.Find(id);
        }

        public IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers;
        }

        public void Update(Supplier changedDataObject)
        {
            context.Update(changedDataObject);
            context.SaveChanges();
        }
    }
}
