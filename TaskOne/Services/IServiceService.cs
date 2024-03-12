using TaskOne.Models.Dtos;

namespace TaskOne.Services
{
    // Yeah, Service is pretty cool name for entity)
    public interface IServiceService
    {
        public ICollection<ServiceDto> GetServices();
        public ServiceDto GetService(int serviceId);
        public ServiceDto UpdateService(ServiceDto serviceDto);
        public ServiceDto CreateService(ServiceDto serviceDto);
        public void DeleteService(int serviceId);
    }
}
