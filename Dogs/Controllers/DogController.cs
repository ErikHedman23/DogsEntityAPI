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
            _context = context; // dependency injection for the database from DataContext to access our "DefaultConnection"
                                // so that we can alter the database.
        }

        [HttpGet] // Read
        public async Task<ActionResult<List<Dog>>> GetAllDogs() //Allows me to see the types for each of the properties for this object
        {
            var dogs = await _context.Dogs.ToListAsync();

            return Ok(dogs);
        }

        [HttpGet("{id}")] // using the value from /api/Dog/{id} as the direct route
        public async Task<ActionResult<Dog>> GetDog(int id) 
        {
            var dog = await _context.Dogs.FindAsync(id);
            if (dog is null)
                return NotFound("Dog not found.");

            return Ok(dog);
        }

        [HttpPost] //Create
        public async Task<ActionResult<List<Dog>>> AddDog(Dog dog) 
        {
            _context.Dogs.Add(dog);
            await _context.SaveChangesAsync();

            return Ok(await _context.Dogs.ToListAsync()); // returning a list of the current dogs and the new one
        }

        [HttpPut] //Update
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

            return Ok(await _context.Dogs.ToListAsync()); // returning a list of the updated dogs
        }

        [HttpDelete] //Delete
        public async Task<ActionResult<List<Dog>>> DeleteDog(int id)
        {
            var dbDog = await _context.Dogs.FindAsync(id);
            if (dbDog is null)
                return NotFound("Dog not found.");

            _context.Dogs.Remove(dbDog);
            await _context.SaveChangesAsync();

            return Ok(await _context.Dogs.ToListAsync()); // returning an updated list of dogs without the one removed
        }
    }
}
