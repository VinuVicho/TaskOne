using TaskOne.Exceptions;
using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface IServiceRepo
    {
        /// <summary>
        /// Method to return all Services
        /// </summary>
        /// <returns>List of Services</returns>
        public ICollection<Service> GetServices();

        /// <summary>
        /// Method to get Specific Service
        /// </summary>
        /// <param name="id">Id of requested Service</param>
        /// <returns>Service with requested Id or null if not exists</returns>
        public Service GetServiceById(int id);

        /// <summary>
        /// Method to update Service.
        /// </summary>
        /// <remarks>Also returns Id of <see cref="Order"/>s that has this Service</remarks>
        /// <exception cref="NotFoundException">If Service not exists</exception>
        /// <param name="service"></param>
        /// <returns>Updated Service, Set of <see cref="Order"/>.OrderId (to update)</returns>
        public (Service, HashSet<int>) UpdateService(Service service);

        /// <summary>
        /// Method to create new <see cref="Service"/>.
        /// </summary>
        /// <param name="service">Service to create</param>
        /// <returns>Created Service</returns>
        public Service CreateService(Service service);

        /// <summary>
        /// Method to delete specific <see cref="Service"/> and connected <see cref="OrderDetail"/>
        /// </summary>
        /// <remarks>Also returns Id of <see cref="Order"/>s that has this Service</remarks>
        /// <exception cref="NotFoundException">If Service already does not exist</exception>
        /// <param name="serviceId">Id of Service to delete</param>
        /// <returns>Set of <see cref="Order"/>.OrderId (to update)</returns>
        public HashSet<int> DeleteService(int serviceId);
    }
}
