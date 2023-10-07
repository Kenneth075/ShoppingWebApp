namespace ShoppingWebApp.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ShoppingWebAppDbContext _shoppingWebAppDbContext;
        private readonly IShoppingCartRepository _shoppingCart;

        public OrderRepository(ShoppingWebAppDbContext shoppingWebAppDbContext, IShoppingCartRepository shoppingCart)
        {
            _shoppingWebAppDbContext = shoppingWebAppDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            order.OrderDetails = new List<OrderDetail>();

            //adding the order with its details

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    Amount = shoppingCartItem.Amount,
                    PiesId = shoppingCartItem.Pies.PiesId,
                    Price = shoppingCartItem.Pies.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _shoppingWebAppDbContext.Orders.Add(order);

            _shoppingWebAppDbContext.SaveChanges();
        }
    }
}
