using CountryServiceVrijdag.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryServiceVrijdag.Controllers
{
    [Route("apicountry/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private ICountryRepository repo;

        public CountryController(ICountryRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet("continent/{continent}/{id}")]
        public IEnumerable<Country> Get(string continent, int id,[FromQuery] string? capital)
        {
            if (!string.IsNullOrEmpty(continent))
            {
                if (!string.IsNullOrEmpty(capital))
                    return repo.GetAll(continent, capital);
                else 
                    return repo.GetAll(continent);
            }
            else 
                return repo.GetAll();
        }
        [HttpHead("{id}")]
        [HttpGet("{id}")]
        public ActionResult<Country> Get(int id)
        {
            try
            {
                return Ok(repo.GetCountry((int)id));
            }
            catch (CountryException e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
