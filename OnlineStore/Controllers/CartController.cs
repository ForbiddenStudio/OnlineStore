using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models;
using OnlineStoreDomain;
using OnlineStoreRepository;
using OnlineStoreService;

namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        private IProductsRepository _repository;
      //  private IOrderProcessor _processor;
        public CartController(IProductsRepository repository)// IOrderProcessor processor)
        {
            _repository = repository;
           // _processor = processor;
        }
        public ViewResult Index(CartService cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public PartialViewResult Summary(CartService cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            return View(); //new ShippingDetailsEntity());
        }
        [HttpPost]
        public ViewResult Checkout(CartService cart)//, ShippingDetailsEntity shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
               // _processor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View();//shippingDetails);
            }
        }
        public RedirectToRouteResult AddToCart(CartService cart, int Id, string returnUrl)
        {
            ProductEntity product = _repository.GetAll().ToArray()
                .FirstOrDefault(g => g.Id == Id);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(CartService cart, int Id, string returnUrl)
        {
            ProductEntity product = _repository.GetAll().ToArray()
                .FirstOrDefault(g => g.Id == Id);

            if (product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
    }
}