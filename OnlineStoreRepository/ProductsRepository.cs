using System.Data.Entity;
using System.Globalization;
using System.Linq;
using OnlineStoreDomain;

namespace OnlineStoreRepository
{
    public class ProductsRepository : BaseRepository<ProductEntity>, IProductsRepository
    {

        public ProductsRepository(DbContext context) : base(context)
        {
        }

        public void SaveProduct(ProductEntity product)
        {
            if (product.Id == 0)
                //_entities.Add(product);
                Add(product);
            else
            {
                ProductEntity dbEntry = Get(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Volume = product.Volume;
                    dbEntry.Price = product.Price;
                    dbEntry.TypeEntityId = product.TypeEntityId;
                }
            }
            Save();
        }
    }

    public interface IProductsRepository : IBaseRepository<ProductEntity>
    {
        void SaveProduct(ProductEntity product);
    }
}