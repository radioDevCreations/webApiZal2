using Application.Models.User;
using AutoMapper;

namespace Application.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<RegisterUser, Domain.Entities.User>();
            CreateMap<Domain.Entities.User, Domain.Entities.User>();
        }
    }
}
