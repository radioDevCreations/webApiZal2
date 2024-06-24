
using Application.Models.Boat;
using AutoMapper;

namespace Application.Mapper
{
    public class BoatMapper : Profile
    {
        public BoatMapper()
        {
            CreateMap<CreateBoat, Domain.Entities.Boat>();
            CreateMap<Domain.Entities.Boat, Domain.Entities.Boat>();
        }
    }
}
