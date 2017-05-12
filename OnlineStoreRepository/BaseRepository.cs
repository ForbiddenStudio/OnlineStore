using System.Data.Entity;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStoreDomain;

namespace OnlineStoreRepository
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        T Get(int id);
        T Add(T entity);
        void Delete(T entity);
        T Delete(int Id);
        void Update(T entity);
        void Save();
       // void SaveProduct(T product);
       // T DeleteProduct(int Id);
    }
    public class BaseRepository<T>:IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _entities;
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public T Get(int id)
        {
            return _entities.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }
        public T Delete(int Id)
        {
            T dbEntry = _entities.Find(Id);
            if (dbEntry != null)
            {
                _entities.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public T Add(T entity)
        {
            return _entities.Add(entity);
        }
        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }
        //public void SaveProduct(T product)
        //{
        //    if (product.Id == 0)
        //        _entities.Add(product);
        //    else
        //    {
        //        T dbEntry = _entities.Find(product.Id);
        //        if (dbEntry != null)
        //        {
        //            dbEntry.Name = product.Name;
        //            dbEntry.Volume = product.Volume;
        //            dbEntry.Price = product.Price;
        //            dbEntry.TypeEntityId = product.TypeEntityId;
        //        }
        //    }
        //    _context.SaveChanges();
        //}
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
