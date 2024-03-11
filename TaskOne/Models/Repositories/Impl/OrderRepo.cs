using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories.Impl
{
    public class OrderRepo(AppDbContext context) : IOrderRepo
    {
        public ICollection<Order> GetOrders()
        {
            return [.. context.Orders];
        }
    }
}
