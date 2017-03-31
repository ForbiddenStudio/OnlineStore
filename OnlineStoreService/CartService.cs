using System.Collections.Generic;
using System.Linq;
using OnlineStoreDomain;

namespace OnlineStoreService
{
    public class CartService
    {
        private List<CartEntity> lineCollection = new List<CartEntity>();

        public void AddItem(ProductEntity product, int quantity)
        {
            CartEntity line = lineCollection
                .Where(g => g.ProductEntity.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartEntity
                {
                    ProductEntity = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(ProductEntity product)
        {
            lineCollection.RemoveAll(l => l.ProductEntity.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.ProductEntity.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartEntity> Lines
        {
            get { return lineCollection; }
        }
    }
}