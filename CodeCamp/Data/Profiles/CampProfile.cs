using AutoMapper;
using CodeCamp.Data.Entities;
using CodeCamp.Models;

namespace CodeCamp.Data
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            this.CreateMap<Camp, CampModel>()
                .ForMember(c => c.Venue, o => o.MapFrom(m => m.Location.VenueName));
        }
    }
}