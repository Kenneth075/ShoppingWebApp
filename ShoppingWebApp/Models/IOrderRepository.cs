namespace ShoppingWebApp.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
