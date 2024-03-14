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
        /// <returns>ServiceDto with requested Id or null if not exists</returns>
        public Service GetServiceById(int id);
        /// <summary>
        /// Method to update Service. 
        /// </summary>
        /// <remarks>Also price of <see cref="Order"/> that has this Service</remarks>
        /// <param name="service">Service to Update</param>
        /// <exception cref="NotFoundException">If there is no Service with Id</exception>
        /// <returns>Updated ServiceDto</returns>
        public Service UpdateService(Service service);
        /// <summary>
        /// Method to create new Service.
        /// </summary>
        /// <param name="service">Service to create</param>
        /// <returns>Created Service</returns>
        public Service CreateService(Service service);
        /// <summary>
        /// Method to delete specific Service and connected <see cref="OrderDetail"/>
        /// </summary>
        /// <remarks>Also updates price of <see cref="Order"/> that had this Service</remarks>
        /// <param name="serviceId">Id of Service to delete</param>
        /// <returns>false if there is nothing to delete, otherwise true</returns>
        public bool DeleteService(int serviceId);
    }
}
