using Application.Models.Harbour;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class HarbourMapper : Profile
    {
        public HarbourMapper() 
        {
            CreateMap<Harbour, CreateHarbour>();
            CreateMap<CreateHarbour, Harbour>();
        }
    }
}
