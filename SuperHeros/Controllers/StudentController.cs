using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeros.Data;

namespace SuperHeros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;

        public StudentController(DataContext Context)
        {
            _context = Context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(await _context.Students.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Student>>> AddHero(Student AddStudent)
        {

            _context.Students.Add(AddStudent);
            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var getStudent = await _context.Students.FindAsync(id);
            if (getStudent == null)
            {
                return BadRequest("Student doesnot Exist");
            }
            return Ok(getStudent);
        }

        [HttpPut]
        public async Task<ActionResult<List<Student>>> Updatehero(Student request)
        {
            var UPStudent = await _context.Students.FindAsync(request.Id);
            if (UPStudent == null)
            {
                return BadRequest("Hero doesnot Exist");
            }

            UPStudent.Name = request.Name;
            UPStudent.Class = request.Class;
            UPStudent.TeacherId = request.TeacherId;

            await _context.SaveChangesAsync();

            return Ok(await _context.Students.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> Delete(int id)
        {
            var DStudent = await _context.Students.FindAsync(id);
            if (DStudent == null)
            {
                return BadRequest("Hero doesnot Exist");
            }

            _context.Students.Remove(DStudent);
            await _context.SaveChangesAsync();
            return Ok(await _context.Students.ToListAsync());
        }
    }
}
