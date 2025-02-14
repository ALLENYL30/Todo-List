using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;
using TodoApi.Repositories;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _repository;

        public TodosController(ITodoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/todos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAll()
        {
            return Ok(await _repository.GetAllAsync());
        }

        // GET: api/todos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetById(int id)
        {
            var item = await _repository.GetByIdAsync(id);
            return item != null ? Ok(item) : NotFound();
        }

        // POST: api/todos
        [HttpPost]
        public async Task<ActionResult<TodoItem>> Create(TodoItem item)
        {
            var createdItem = await _repository.AddAsync(item);
            return CreatedAtAction(nameof(GetById), new { id = createdItem.Id }, createdItem);
        }

        // PUT: api/todos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TodoItem item)
        {
            if (id != item.Id) return BadRequest();
            await _repository.UpdateAsync(item);
            return NoContent();
        }

        // DELETE: api/todos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
} 