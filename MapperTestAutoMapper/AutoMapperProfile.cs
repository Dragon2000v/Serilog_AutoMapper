using AutoMapper;

namespace MapperTestAutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<SuperHero, SuperHeroDto>();
            CreateMap<SuperHeroDto,SuperHero>();
        }
    }
}
