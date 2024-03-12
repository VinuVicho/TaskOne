using TaskOne.Models.Dtos;

namespace TaskOne.Services
{
    /**
     * Yeah, Service is pretty cool name for entity)
     */
    public interface IServiceService
    {
        public ICollection<ServiceDto> GeServices();
        public ServiceDto GetService(int id);
        public ServiceDto UpdateOrder(ServiceDto serviceDto);
        public ServiceDto CreateOrder(ServiceDto serviceDto);
        public void DeleteService(int id);
    }
}
