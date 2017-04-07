using System.Web.Mvc;
using OnlineStoreService;

namespace OnlineStore.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "CartService";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            // Получить объект Cart из сеанса
            CartService cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (CartService)controllerContext.HttpContext.Session[sessionKey];
            }

            // Создать объект Cart если он не обнаружен в сеансе
            if (cart == null)
            {
                cart = new CartService();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

            // Возвратить объект Cart
            return cart;
        }
    }
}