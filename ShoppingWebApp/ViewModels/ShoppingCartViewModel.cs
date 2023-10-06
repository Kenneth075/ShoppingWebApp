using ShoppingWebApp.Models;

namespace ShoppingWebApp.ViewModels
{
    public class ShoppingCartViewModel
    {

        public IShoppingCartRepository ShoppingCartRepository { get; }
        public decimal ShoppingCartTotal { get; }

        public ShoppingCartViewModel(IShoppingCartRepository shoppingCartRepository, decimal shoppingCartTotal)
        {
            ShoppingCartRepository = shoppingCartRepository;
            ShoppingCartTotal = shoppingCartTotal;

        }
    }
}
