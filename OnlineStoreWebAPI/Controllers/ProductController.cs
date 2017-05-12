using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineStoreDomain;
using OnlineStoreRepository;
using OnlineStoreService.Models;

namespace OnlineStoreWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private IProductsRepository _repository;

        public ProductController(IProductsRepository repository)
        {
            _repository = repository;
        }

        // GET /product/
        public IEnumerable<ProductModel> GetAll()
        {
            return _repository.GetAll().Select(product => new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                TypeEntityId = product.TypeEntityId,
                Volume = product.Volume

            });
        }
     
        public ProductModel Add(ProductEntity entity)
        {
           var product = _repository.Add(entity);
            return  new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                TypeEntityId = product.TypeEntityId,
                Volume = product.Volume
            };
        }

        public void Delete(ProductEntity entity)
        {
            _repository.Delete(entity);
        }

        public void Update(ProductEntity entity)
        {
           _repository.Update(entity);
        }

        public void SaveProduct(ProductEntity product)
        {
            _repository.SaveProduct(product);
        }

        // GET /product/1     
        public ProductModel Get(int id)
        {
            var product = _repository.Get(id);
            return new ProductModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                TypeEntityId = product.TypeEntityId,
                Volume = product.Volume
            };
        }

        [System.Web.Http.HttpPost]
        public void Post(ProductEntity item)
        {
            _repository.SaveProduct(item);
        }

        // DELETE /product/1
        public void Delete(int id)
        {
            _repository.Delete(id);
        }       
    }
}
