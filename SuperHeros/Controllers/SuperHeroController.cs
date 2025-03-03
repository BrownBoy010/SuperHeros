using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeros.Data;
using System.Collections.Immutable;

namespace SuperHeros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;

        public SuperHeroController(DataContext Context)
        {
            _context = Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHeros>>> Get()
        {
            return Ok(await _context.SuperHeros.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHeros>> Get(int id)
        {
            var hero = await _context.SuperHeros.FindAsync(id);
            if(hero == null)
            {
                return BadRequest("Super Hero doesnot Exist");
            }
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHeros>>> AddHero(SuperHeros hero)
        {
            _context.SuperHeros.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeros.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHeros>>> Updatehero(SuperHeros request)
        {
            var UPhero = await _context.SuperHeros.FindAsync(request.id);
            if (UPhero == null)
            {
                return BadRequest("Hero doesnot Exist");
            }
            UPhero.name=request.name;
            UPhero.age=request.age;
            UPhero.SuperName=request.SuperName;

            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeros.ToListAsync());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] SuperHeros updatedhero)
        {
            var existingHero = _context.SuperHeros.FirstOrDefault(item => item.id == id);

            if (existingHero == null)
            {
                return NotFound();
            }
            existingHero.name = updatedhero.name;
            existingHero.age = updatedhero.age;
            existingHero.SuperName = updatedhero.SuperName;

            _context.SaveChanges();
            return Ok(existingHero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SuperHeros>> Delete(int id)
        {
            var Dhero = await _context.SuperHeros.FindAsync(id);
            if (Dhero == null)
            {
                return BadRequest("Hero doesnot Exist");
            }

            _context.SuperHeros.Remove(Dhero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeros.ToListAsync());
        }
    }
}
