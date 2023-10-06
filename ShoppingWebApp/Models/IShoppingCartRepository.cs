namespace ShoppingWebApp.Models
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Pies pie);
        int RemoveFromCart(Pies pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
        List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
