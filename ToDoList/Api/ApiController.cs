using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly NotesDbContext dbContext;

        public ApiController(NotesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Notes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var note = await dbContext.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(await dbContext.Notes.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Note note)
        {
            await dbContext.Notes.AddAsync(note);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var note = await dbContext.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            dbContext.Remove(note);
            await dbContext.SaveChangesAsync();
            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {

            dbContext.RemoveRange(dbContext.Notes);
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
