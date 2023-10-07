using System.IO.Pipelines;

namespace ShoppingWebApp.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int PiesId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public Pies Pie { get; set; } = default!;
        public Order Order { get; set; } = default!;
    }
}
