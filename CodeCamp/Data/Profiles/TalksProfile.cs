using AutoMapper;
using CodeCamp.Data.Entities;
using CodeCamp.Models;

namespace CodeCamp.Data
{
    public class TalksProfile : Profile
    {
        public TalksProfile()
        {
            this.CreateMap<Talk, TalkModel>();

        }
    }
}