using AutoMapper;
using Common.Dtos;
using Common.Dtos.TaskDTOs;
using Common.Dtos.UserDTOs;
using Common.Responses;
using Common.ViewModels.TaskViewModels;
using Common.ViewModels.UserViewModels;

using Models.Models.SystemUsers;
using Models.Models.TaskInfo;
using System.Linq;

namespace Services
{

    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<TaskInfo, TaskDTO>().ReverseMap();
            CreateMap<Result<TaskInfo>, Result<TaskDTO>>().ReverseMap();
            CreateMap<TaskInfo, TaskViewModel>().ReverseMap();
            CreateMap<Result<TaskInfo>, Result<TaskViewModel>>().ReverseMap();
        }
    }
}
