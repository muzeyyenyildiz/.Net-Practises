using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
       
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return await NewMethod();
        }

        private async Task<ActionResult<List<SuperHero>>> NewMethod()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetById(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if(hero == null)
            {
                return BadRequest("Hero not found!");
            }
            else
            {
                return Ok(hero);
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
        {

            var dbhero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbhero == null)
            {
                return BadRequest("Hero not found!");
            }
            else
            {
                dbhero.Name = request.Name;
                dbhero.FirstName = request.FirstName;
                dbhero.LastName = request.LastName;
                dbhero.Place = request.Place;

                await _context.SaveChangesAsync();

                return Ok(await _context.SuperHeroes.ToListAsync());
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(id);
            if (dbhero == null)
            {
                return BadRequest("Hero not found!");
            }
            else
            {
                _context.SuperHeroes.Remove(dbhero);
                await _context.SaveChangesAsync();
                return Ok(await _context.SuperHeroes.ToListAsync());
            }

        }
    }
}
