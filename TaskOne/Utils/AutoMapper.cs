using AutoMapper;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;

namespace TaskOne.Utils
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<CustomerCreateRequest, Customer>();

            CreateMap<Executor, ExecutorRequestDto>().ReverseMap();
            CreateMap<Executor, ExecutorDto>().ReverseMap();
            CreateMap<ExecutorLoginDto, Executor>();
            CreateMap<ExecutorUpdateRequest, Executor>();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderFullyDto>();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailWithServiceDto>();
            CreateMap<OrderDetailsCreateRequest, OrderDetail>();

            CreateMap<Service, ServiceDto>().ReverseMap();
            CreateMap<ServiceCreateRequest, Service>();
        }
    }
}
