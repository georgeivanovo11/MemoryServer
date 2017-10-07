using AutoMapper;
using MemoryServer.Models;
using MemoryServer.Resources;

namespace MemoryServer.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<PartOfSpeech,PartOfSpeechResource>();
            CreateMap<EngWord,EngWordResource>();
            CreateMap<RusWord,RusWordResource>();
        }
    }
}