using Microsoft.AspNetCore.Mvc;
using WebToDoList.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebToDoList.Models;
using Microsoft.EntityFrameworkCore;

namespace WebToDoList.Controllers
{
    [ApiController]
    [Route("[controller]")] // Endpoint base URL: http://localhost:<port>/ToDoList
    public class ToDoListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ToDoListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /ToDoList
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoList>>> GetToDoLists()
        {
            return await _context.toDoLists.ToListAsync();
        }

        // GET: /ToDoList/5
        //get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoList>> GetToDoList(int id)
        {
            var toDoList = await _context.toDoLists.FindAsync(id);

            if (toDoList == null)
            {
                return NotFound();
            }

            return toDoList;
        }

        // POST: /ToDoList
        [HttpPost]
        public async Task<ActionResult<ToDoList>> PostToDoList(ToDoList toDoList)
        {
            _context.toDoLists.Add(toDoList);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDoList), new { id = toDoList.Id_work }, toDoList);
        }

        // PUT: /ToDoList/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutToDoList(int id, ToDoList toDoList)
        //{
        //    if (id != toDoList.Id_work)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(toDoList).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ToDoListExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // DELETE: /ToDoList/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            var toDoList = await _context.toDoLists.FindAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }

            _context.toDoLists.Remove(toDoList);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
