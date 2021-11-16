using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ListTasks.Context;
using ListTasks.Models;

namespace ListTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksModelsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksModelsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TasksModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TasksModels>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/TasksModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TasksModels>> GetTasksModels(int id)
        {
            var tasksModels = await _context.Tasks.FindAsync(id);

            if (tasksModels == null)
            {
                return NotFound();
            }

            return tasksModels;
        }

        // PUT: api/TasksModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTasksModels(int id, TasksModels tasksModels)
        {
            if (id != tasksModels.Id)
            {
                return BadRequest();
            }

            _context.Entry(tasksModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksModelsExists(id))
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

        // POST: api/TasksModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TasksModels>> PostTasksModels(TasksModels tasksModels)
        {
            _context.Tasks.Add(tasksModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasksModels", new { id = tasksModels.Id }, tasksModels);
        }

        // DELETE: api/TasksModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasksModels(int id)
        {
            var tasksModels = await _context.Tasks.FindAsync(id);
            if (tasksModels == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(tasksModels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TasksModelsExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
