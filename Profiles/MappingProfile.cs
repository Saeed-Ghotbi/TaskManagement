using AutoMapper;
using TaskManagement.DTOs.User;
using TaskManagement.Model;

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
        }


    }
}
