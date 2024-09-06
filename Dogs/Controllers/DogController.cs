using Microsoft.AspNetCore.Mvc;
using Dogs.Entities;
using Dogs.Data;
using Microsoft.EntityFrameworkCore;

namespace Dogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogController : ControllerBase
    {
        private readonly DataContext _context;
        public DogController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dog>>> GetAllDogs() //Allows me to see the types for each of the properties for this object
        {
            var dogs = await _context.Dogs.ToListAsync();

            return Ok(dogs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id) 
        {
            var dog = await _context.Dogs.FindAsync(id);
            if (dog is null)
                return NotFound("Dog not found.");

            return Ok(dog);
        }

        [HttpPost]
        public async Task<ActionResult<List<Dog>>> AddDog(Dog dog) 
        {
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();

            return Ok(await _context.Dogs.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Dog>>> UpdateDog(Dog updatedDog)
        {
            var dbDog = await _context.Dogs.FindAsync(updatedDog.Id);
            if (dbDog is null)
                return NotFound("Dog not found.");

            dbDog.Name = updatedDog.Name;
            dbDog.Home = updatedDog.Home;
            dbDog.Age = updatedDog.Age;
            dbDog.Description = updatedDog.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Dogs.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Dog>>> DeleteDog(int id)
        {
            var dbDog = await _context.Dogs.FindAsync(id);
            if (dbDog is null)
                return NotFound("Dog not found.");

            _context.Dogs.Remove(dbDog);
            await _context.SaveChangesAsync();

            return Ok(await _context.Dogs.ToListAsync());
        }
    }
}
