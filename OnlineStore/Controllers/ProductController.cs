using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OnlineStore.Models;
using OnlineStoreRepository;
using OnlineStoreService;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository _repository;
        public int pageSize = 4;
        private ITypeService _service;

        public ProductController(IProductsRepository repository, ITypeService service )
        {
             _repository = repository;
            _service = service;
        }
        // GET: Product
        public ViewResult List(string category, int page = 1)
        {
            ProductListModel model = new ProductListModel
            {
                Product = _repository.GetAll().ToArray()
                .Where(p => category == null|| _service.GetTypeName(p.TypeEntityId) == category)
                .OrderBy(product => product.Id)
                .Skip((page-1)*pageSize)
                .Take(pageSize),              
                
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = _repository.GetAll().Count()
                },

                CurrentCategory = category
            };

            return View(model);
        }
    }
}