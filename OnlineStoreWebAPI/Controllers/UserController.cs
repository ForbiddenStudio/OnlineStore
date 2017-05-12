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
    public class UserController : ApiController
    {
        private IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET /product/
        public IEnumerable<UserModel> GetAll()
        {
            return _repository.GetAll().Select(product => new UserModel
            {
                Id = product.Id,
                Email = product.Email,
                PasswordHash = product.PasswordHash,
                UserName = product.UserName
                //ProductEntity = _repository1.GetAll().Where(== )



            });
        }

        public UserModel Add(AppUser entity)
        {
            var product = _repository.Add(entity);
            return new UserModel
            {
                Id = product.Id,
                Email = product.Email,
                PasswordHash = product.PasswordHash,
                UserName = product.UserName
            };
        }

        public void Delete(AppUser entity)
        {
            _repository.Delete(entity);
        }

        public void Update(AppUser entity)
        {
            _repository.Update(entity);
        }

        // GET /product/1     
        public UserModel Get(int id)
        {
            var product = _repository.Get(id);
            return new UserModel
            {
                Id = product.Id,
                Email = product.Email,
                PasswordHash = product.PasswordHash,
                UserName = product.UserName
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
