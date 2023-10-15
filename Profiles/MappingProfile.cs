using AutoMapper;
using TaskManagement.DTOs.Status;
using TaskManagement.DTOs.Subject;
using TaskManagement.DTOs.Task;
using TaskManagement.DTOs.User;
using TaskManagement.Model;
using Task = TaskManagement.Model.Task;

namespace TaskManagement.Profiles
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            #region User

            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, ProfileUser>();
            CreateMap<UpdateUserDto, User>();
            CreateMap<UpdateUserDto, ProfileUser>();

            #endregion

            #region Status
            CreateMap<StatusDto, Status>();

            #endregion

            #region Subject
            CreateMap<SubjectDto, Subject>();

            #endregion

            #region Task
            CreateMap<CreateTaskDto, Task>();


            #endregion
        }


    }
}
