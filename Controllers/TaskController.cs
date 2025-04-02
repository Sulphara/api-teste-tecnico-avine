using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskContext _context;

        public TaskController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            try
            {
                return await _context.Tasks.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao buscar tarefas.", error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound(new { message = "Tarefa não encontrada." });

            return task;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            if (task.FinishedAt < DateTime.UtcNow)
            {
                return BadRequest(new { message = "A data final deve ser no futuro." });
            }

            task.FinishedAt = task.FinishedAt.Date;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskItem task)
        {
            if (id != task.Id)
                return BadRequest(new { message = "ID da tarefa não corresponde ao parâmetro da URL." });

            if (!ModelState.IsValid)
                return BadRequest(new { message = "Dados inválidos.", errors = ModelState });

            var existingTask = await _context.Tasks.FindAsync(id);
            if (existingTask == null)
                return NotFound(new { message = "Tarefa não encontrada." });

            try
            {
                _context.Entry(existingTask).CurrentValues.SetValues(task);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao atualizar a tarefa.", error = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
                return NotFound(new { message = "Tarefa não encontrada." });

            try
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Erro ao excluir a tarefa.", error = ex.Message });
            }
        }
    }
}
