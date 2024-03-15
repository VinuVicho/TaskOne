using AutoMapper;
using TaskOne.Exceptions;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class ServiceService(IServiceRepo serviceRepo, IOrderService orderService, IMapper mapper): IServiceService
    {
        /// <inheritdoc />
        public ICollection<ServiceDto> GetServices()
        {
            return serviceRepo.GetServices().Select(mapper.Map<ServiceDto>).ToList();
        }

        /// <inheritdoc />
        public ServiceDto GetService(int serviceId)
        {
            var service = serviceRepo.GetServiceById(serviceId);
            return service == null
                ? throw new NotFoundException("Service not found with id: " + serviceId)
                : mapper.Map<ServiceDto>(service);
        }

        /// <inheritdoc />
        public ServiceDto UpdateService(ServiceDto serviceDto)
        {
            var result = serviceRepo.UpdateService(mapper.Map<Service>(serviceDto));

            foreach (var orderId in result.Item2)
            {
                orderService.UpdateOrderPrice(orderId);
            }
            return mapper.Map<ServiceDto>(result.Item1);
        }

        /// <inheritdoc />
        public ServiceDto CreateService(ServiceCreateRequest serviceDto)
        {
            var resultService = serviceRepo.CreateService(mapper.Map<Service>(serviceDto));
            return mapper.Map<ServiceDto>(resultService);
        }

        /// <inheritdoc />
        public void DeleteService(int serviceId)
        {
            var orderIds = serviceRepo.DeleteService(serviceId);
            foreach (var orderId in orderIds)
            {
                orderService.UpdateOrderPrice(orderId);
            }
        }

    }
}
