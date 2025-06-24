using AutoMapper;
using TaskManagerPro.API.Models;
using TaskManagerPro.API.Dtos;

namespace TaskManagerPro.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaskItem, TaskItemDto>();
            CreateMap<TaskItemDto, TaskItem>();
            CreateMap<UpdateTaskDto, TaskItem>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
