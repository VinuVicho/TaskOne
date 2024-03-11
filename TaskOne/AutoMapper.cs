using AutoMapper;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;

namespace TaskOne
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Executor, ExecutorRequestDto>().ReverseMap();
            CreateMap<Executor, ExecutorDto>();
            CreateMap<ExecutorLoginDto, Executor>();
        }
    }
}
