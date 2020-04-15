using AutoMapper;
using CodeCamp.Data.Entities;

namespace CodeCamp.Data
{
    public class CampProfile : Profile
    {
        public CampProfile()
        {
            this.CreateMap<Camp, CampModel>();
        }
        
    }
}