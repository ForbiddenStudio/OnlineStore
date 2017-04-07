using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using OnlineStoreDomain;

namespace OnlineStore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(ProductEntity productEntity, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Product.Id == productEntity.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product = productEntity,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(ProductEntity productEntity)
        {
            lineCollection.RemoveAll(l => l.Product.Id== productEntity.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public ProductEntity Product{ get; set; }
        public int Quantity { get; set; }
    }
}