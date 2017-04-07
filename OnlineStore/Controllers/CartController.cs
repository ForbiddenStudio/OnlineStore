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
        public RedirectToRouteResult AddToCart(int Id, string returnUrl)
        {
            ProductEntity product = _repository.GetAll().ToArray()
                .FirstOrDefault(g => g.Id == Id);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int Id, string returnUrl)
        {
            ProductEntity game = _repository.GetAll().ToArray()
                .FirstOrDefault(g => g.Id == Id);

            if (game != null)
            {
                GetCart().RemoveLine(game);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public CartService GetCart()
        {
            CartService cart = (CartService)Session["Cart"];
            if (cart == null)
            {
                cart = new CartService();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }
    }
}