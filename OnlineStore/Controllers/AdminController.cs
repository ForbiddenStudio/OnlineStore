using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStoreDomain;
using OnlineStoreRepository;

namespace OnlineStore.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private IProductsRepository _repository;

        public AdminController(IProductsRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Index()
        {
            return View(_repository.GetAll().ToArray());
        }
        public ViewResult Edit(int Id)
        {
            ProductEntity product = _repository.GetAll().ToArray()
                .FirstOrDefault(g => g.Id == Id);
            return View(product);
        }

        public ViewResult Create()
        {
            return View("Edit", new ProductEntity());
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            ProductEntity deletedProduct = _repository.DeleteProduct(Id);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Продукт \"{0}\" был удален",
                    deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    

    [HttpPost]
        public ActionResult Edit(ProductEntity product)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveProduct(product);
                TempData["message"] = string.Format("Изменения в продукте \"{0}\" были сохранены", product.Name);
                return RedirectToAction("Index");
            }
            else
            {

                return View(product);
            }
        }
    }
}