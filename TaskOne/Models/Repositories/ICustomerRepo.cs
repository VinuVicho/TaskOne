using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface ICustomerRepo
    {
        ICollection<Customer> getCustomers();
    }
}
