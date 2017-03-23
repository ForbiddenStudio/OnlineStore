using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreDomain;

namespace OnlineStoreRepository
{
    public interface IProductsRepository
    {
        IQueryable<ProductEntity> GetAll();
        ProductEntity Get(int id);
        ProductEntity Add(ProductEntity entity);
        void Delete(ProductEntity entity);
        void Update(ProductEntity entity);
        void Save();
        void SaveProduct(ProductEntity product);
        ProductEntity DeleteProduct(int Id);
    }
    public class ProductRepository: IProductsRepository
    {
        private readonly DbSet<ProductEntity> _entities;
        private readonly DbContext _context;

        public ProductRepository(DbContext context)
        {
            _context = context;
            _entities = _context.Set<ProductEntity>();
        }

        public ProductEntity Get(int id)
        {
            return _entities.Find(id);
        }

        public IQueryable<ProductEntity> GetAll()
        {
            return _entities.AsQueryable();
        }
        public ProductEntity DeleteProduct(int Id)
        {
            ProductEntity dbEntry = _entities.Find(Id);
            if (dbEntry != null)
            {
                _entities.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
        public ProductEntity Add(ProductEntity entity)
        {
            return _entities.Add(entity);
        }
        public void Delete(ProductEntity entity)
        {
            _entities.Remove(entity);
        }
        public void SaveProduct(ProductEntity product)
        {
            if (product.Id == 0)
                _entities.Add(product);
            else
            {
                ProductEntity dbEntry = _entities.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Volume = product.Volume;
                    dbEntry.Price = product.Price;
                    dbEntry.TypeEntityId = product.TypeEntityId;
                }
            }
            _context.SaveChanges();
        }
        public void Update(ProductEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
//Раз-два раз-два