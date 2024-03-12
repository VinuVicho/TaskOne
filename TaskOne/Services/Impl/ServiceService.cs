using AutoMapper;
using TaskOne.Exceptions;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class ServiceService(IServiceRepo serviceRepo, IMapper mapper): IServiceService
    {
        public ICollection<ServiceDto> GetServices()
        {
            return serviceRepo.GetServices().Select(mapper.Map<ServiceDto>).ToList();
        }

        public ServiceDto GetService(int serviceId)
        {
            var service = serviceRepo.GetServiceById(serviceId);
            return service == null
                ? throw new NotFoundException("Service not found with id: " + serviceId)
                : mapper.Map<ServiceDto>(service);
        }

        public ServiceDto UpdateService(ServiceDto serviceDto)
        {
            var resultService = serviceRepo.UpdateService(mapper.Map<Service>(serviceDto));
            return mapper.Map<ServiceDto>(resultService);
        }

        public ServiceDto CreateService(ServiceDto serviceDto)
        {
            var resultService = serviceRepo.CreateService(mapper.Map<Service>(serviceDto));
            return mapper.Map<ServiceDto>(resultService);
        }

        public void DeleteService(int serviceId)
        {
            if (!serviceRepo.DeleteService(serviceId))
            {
                throw new NotFoundException("Customer cannot be deleted with id: " + serviceId);
            }
        }
    }
}
