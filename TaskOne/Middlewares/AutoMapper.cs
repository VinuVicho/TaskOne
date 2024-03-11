using AutoMapper;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;

namespace TaskOne.Middlewares
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Executor, ExecutorRequestDto>().ReverseMap();
            CreateMap<Executor, ExecutorDto>();
            CreateMap<ExecutorLoginDto, Executor>();

            CreateMap<Order, OrderDto>().ReverseMap();

            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            CreateMap<Service, ServiceDto>().ReverseMap();
        }
    }
}
