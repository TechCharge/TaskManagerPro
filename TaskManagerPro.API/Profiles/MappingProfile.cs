using AutoMapper;
using TaskManagerPro.API.Models;
using TaskManagerPro.API.Dtos;

namespace TaskManagerPro.API.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity to Response DTO
            CreateMap<TaskItem, TaskItemDto>();

            // Creation DTO to Entity (for POST)
            CreateMap<CreateTaskDto, TaskItem>();

            // Full Update DTO to Entity (for PUT)
            CreateMap<UpdateTaskDto, TaskItem>();

            // Partial Update DTO to Entity (for PATCH), only map non-null values
            CreateMap<PatchTaskDto, TaskItem>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
