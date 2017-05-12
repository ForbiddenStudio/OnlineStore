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
    public class TypeController : ApiController
    {
        private ITypesRepository _repository;
        private IProductsRepository _repository1;
        public TypeController(ITypesRepository repository)
        {
            _repository = repository;
        }

        // GET /product/
        public IEnumerable<TypeModel> GetAll()
        {
            return _repository.GetAll().Select(product => new TypeModel
            {
                Id = product.Id,
                Name = product.Name,
                //ProductEntity = _repository1.GetAll().Where(== )



            });
        }

        public TypeModel Add(TypeEntity entity)
        {
            var product = _repository.Add(entity);
            return new TypeModel
            {
              Id = product.Id,
                Name = product.Name,
                //ProductEntity = product.ProductEntity
            };
        }

        public void Delete(TypeEntity entity)
        {
            _repository.Delete(entity);
        }

        public void Update(TypeEntity entity)
        {
            _repository.Update(entity);
        }

        // GET /product/1     
        public TypeModel Get(int id)
        {
            var product = _repository.Get(id);
            return new TypeModel
            {
                Id = product.Id,
                Name = product.Name,
              //  ProductEntity = product.ProductEntity
            };
        }

        // DELETE /product/1
        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}
