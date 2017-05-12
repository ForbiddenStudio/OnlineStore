using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineStoreDomain;
using OnlineStoreRepository;
using OnlineStoreService.Models;

namespace OnlineStoreWebAPI.Controllers
{
    public class RoleController : ApiController
    {
        private IRoleRepository _repository;
        public RoleController(IRoleRepository repository)
        {
            _repository = repository;
        }

        // GET /product/
        public IEnumerable<RoleModel> GetAll()
        {
            return _repository.GetAll().Select(product => new RoleModel
            {
                Id = product.Id,
               Name = product.Name,
               
              // Users = product.Users
                //ProductEntity = _repository1.GetAll().Where(== )



            });
        }

        public RoleModel Add(AppRole entity)
        {
            var product = _repository.Add(entity);
            return new RoleModel
            {
                Id = product.Id,
                Name = product.Name,
            };
        }

        public void Delete(AppRole entity)
        {
            _repository.Delete(entity);
        }

        public void Update(AppRole entity)
        {
            _repository.Update(entity);
        }

        // GET /product/1     
        public RoleModel Get(int id)
        {
            var product = _repository.Get(id);
            return new RoleModel
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
