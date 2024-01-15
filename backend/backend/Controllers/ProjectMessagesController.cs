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
    public class ProjectMessagesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ProjectMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectMessage>>> GetProjectMessages()
        {
            return await _context.ProjectMessages.ToListAsync();
        }

        // GET: api/ProjectMessages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectMessage>> GetProjectMessage(int id)
        {
            var projectMessage = await _context.ProjectMessages.FindAsync(id);

            if (projectMessage == null)
            {
                return NotFound();
            }

            return projectMessage;
        }

        // PUT: api/ProjectMessages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectMessage(int id, ProjectMessage projectMessage)
        {
            if (id != projectMessage.MessageId)
            {
                return BadRequest();
            }

            _context.Entry(projectMessage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectMessageExists(id))
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

        // POST: api/ProjectMessages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectMessage>> PostProjectMessage(ProjectMessage projectMessage)
        {
            _context.ProjectMessages.Add(projectMessage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProjectMessage", new { id = projectMessage.MessageId }, projectMessage);
        }

        // DELETE: api/ProjectMessages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectMessage(int id)
        {
            var projectMessage = await _context.ProjectMessages.FindAsync(id);
            if (projectMessage == null)
            {
                return NotFound();
            }

            _context.ProjectMessages.Remove(projectMessage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectMessageExists(int id)
        {
            return _context.ProjectMessages.Any(e => e.MessageId == id);
        }
    }
}
