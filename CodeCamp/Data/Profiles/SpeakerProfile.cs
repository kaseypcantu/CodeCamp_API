using AutoMapper;
using CodeCamp.Data.Entities;
using CodeCamp.Models;

namespace CodeCamp.Data.Profiles
{
    public class SpeakerProfile : Profile
    {
        public SpeakerProfile()
        {
            this.CreateMap<Speaker, SpeakerModel>();
        }
    }
}