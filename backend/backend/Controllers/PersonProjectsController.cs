using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.Context;
using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonProjectsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PersonProjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonProject>>> GetPersonProjects()
        {
            return await _context.PersonProjects.ToListAsync();
        }

        // GET: api/PersonProjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonProject>> GetPersonProject(int id)
        {
            var personProject = await _context.PersonProjects.FindAsync(id);

            if (personProject == null)
            {
                return NotFound();
            }

            return personProject;
        }

        // PUT: api/PersonProjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonProject(int id, PersonProject personProject)
        {
            if (id != personProject.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(personProject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonProjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonProjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonProject>> PostPersonProject(PersonProject personProject)
        {
            _context.PersonProjects.Add(personProject);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonProjectExists(personProject.PersonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonProject", new { id = personProject.PersonId }, personProject);
        }

        // DELETE: api/PersonProjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonProject(int id)
        {
            var personProject = await _context.PersonProjects.FindAsync(id);
            if (personProject == null)
            {
                return NotFound();
            }

            _context.PersonProjects.Remove(personProject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonProjectExists(int id)
        {
            return _context.PersonProjects.Any(e => e.PersonId == id);
        }
    }
}
