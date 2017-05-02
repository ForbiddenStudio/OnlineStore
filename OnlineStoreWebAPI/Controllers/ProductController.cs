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
        private IProductsRepository _repository;// = ReservationRepository.Current;

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
            _repository.DeleteProduct(id);
        }
    }
}
