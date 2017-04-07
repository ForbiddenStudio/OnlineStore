using OnlineStoreService;

namespace OnlineStore.Models
{
    public class CartIndexViewModel
    {
        public CartService Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}