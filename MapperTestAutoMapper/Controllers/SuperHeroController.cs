using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MapperTestAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero{ 
                Id = 1,
                Name="Spider Man",
                FirstName="Peter",
                LastName="Parker",
                Place="New York City",
                DataAdded = new DateTime(2001,08,10),
                DataModified = null
            },
             new SuperHero{
                Id = 2,
                Name="Iron Man",
                FirstName="Tony",
                LastName="Stark",
                Place="Malibu",
                DataAdded = new DateTime(1970,05,29),
                DataModified = null
             }
        };

        private readonly IMapper _mapper;

        public SuperHeroController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<SuperHero>> GetHeroes() 
        {     
            
            return Ok(heroes.Select(hero => _mapper.Map<SuperHeroDto>(hero))); 
        }

        [HttpPost]
        public ActionResult<List<SuperHero>> AddHero(SuperHeroDto newHero)
        {
            var hero = _mapper.Map<SuperHero>(newHero);
            heroes.Add(hero);
            return Ok(heroes.Select(hero => _mapper.Map<SuperHeroDto>(hero)));
        }
    }
}
