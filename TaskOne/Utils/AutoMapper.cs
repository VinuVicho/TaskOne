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
            CreateMap<NewCustomerRequest, Customer>();

            CreateMap<Executor, ExecutorRequestDto>().ReverseMap();
            CreateMap<Executor, ExecutorDto>().ReverseMap();
            CreateMap<ExecutorLoginDto, Executor>();
            CreateMap<ExecutorUpdateRequest, Executor>();

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            CreateMap<NewOrderDetailsRequest, OrderDetail>().ReverseMap();

            CreateMap<Service, ServiceDto>().ReverseMap();
        }
    }
}
