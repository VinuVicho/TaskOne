using TaskOne.Exceptions;
using TaskOne.Models.Dtos;

namespace TaskOne.Services
{
    // Yeah, Service is pretty cool name for entity)
    public interface IServiceService
    {
        /// <summary>
        /// Method to get all Services
        /// </summary>
        /// <returns>List of all Services</returns>
        public ICollection<ServiceDto> GetServices();
        /// <summary>
        /// Method to get specific Service
        /// </summary>
        /// <param name="serviceId">Id of requested Service</param>
        /// <exception cref="NotFoundException"></exception>
        /// <returns>ServiceDto with requested Id</returns>
        public ServiceDto GetService(int serviceId);
        /// <summary>
        /// Method to update Service. Updates Service with Id in Dto.
        /// </summary>
        /// <param name="serviceDto">Service to Update</param>
        /// <exception cref="NotFoundException">If there is no Service with Id</exception>
        /// <returns>Updated ServiceDto</returns>
        public ServiceDto UpdateService(ServiceDto serviceDto);
        /// <summary>
        /// Method to create new Service.
        /// </summary>
        /// <param name="serviceDto">Service to create</param>
        /// <returns>Created ServiceDto</returns>
        public ServiceDto CreateService(ServiceCreateRequest serviceDto);
        /// <summary>
        /// Method to delete specific Service
        /// </summary>
        /// <param name="serviceId">Id of Service to delete</param>
        /// <exception cref="NotFoundException">In case, if there is no such Service</exception>
        public void DeleteService(int serviceId);
    }
}
