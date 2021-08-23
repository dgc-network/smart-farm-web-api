using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmEventsController : ControllerBase
    {
        private readonly TodoContext _context;

        public FarmEventsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/FarmEvents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FarmEvent>>> GetFarmEvents()
        {
            return await _context.FarmEvents.ToListAsync();
        }

        // GET: api/FarmEvents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FarmEvent>> GetFarmEvent(long id)
        {
            var item = await _context.FarmEvents.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/FarmEvents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmEvent(long id, FarmEvent todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmEventExists(id))
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

        // POST: api/FarmEvents
        [HttpPost]
        public async Task<ActionResult<FarmEvent>> PostFarmEvent(FarmEvent todoItem)
        {
            _context.FarmEvents.Add(todoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFarmEvent", new { id = todoItem.Id }, todoItem);
        }

        // DELETE: api/FarmEvents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmEvent(long id)
        {
            var todoItem = await _context.FarmEvents.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.FarmEvents.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmEventExists(long id)
        {
            return _context.FarmEvents.Any(e => e.Id == id);
        }
    }
}
