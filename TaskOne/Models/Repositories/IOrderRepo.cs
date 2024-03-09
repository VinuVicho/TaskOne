using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface IOrderRepo
    {
        ICollection<Order> getOrders();
    }
}
