using Business.interfaces;
using Business.services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace gestionTareasBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskService _taskService;
        public TasksController(
            ITaskService taskService
            ) {
            _taskService = taskService;
        }

        // GET: api/<TasksController>
        [HttpGet]
        public IEnumerable<Data.Models.Task> Get()
        
        {
            return _taskService.GetTasks();
        
        }

        //GET api/<TasksController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if(task == null)
            {
                return NotFound(new {message = "No se encontró ningúna tarea con este id"});
            }
            return Ok(task);
        }

        // POST api/<TasksController>
        [HttpPost]
        public IActionResult Post([FromBody] Data.Models.Task newTask)
        {
            if(newTask == null)
            {
                return BadRequest("La tarea no puede ser nula.");
            }
            _taskService.AddTask(newTask);
            return Ok(new { message = "Tarea Agregada con éxito." });
        }

        // PUT api/<TasksController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Data.Models.Task updateTask)
        {
            if (updateTask == null || id != updateTask.id)
            {
                return BadRequest("Datos de la tarea inválidos.");
            }
            var existTask = _taskService.GetTaskById(id);
            if(existTask == null)
            {
                return NotFound("No se encontró la tarea especificada.");
            }

            existTask.isCompleted = updateTask.isCompleted;
            existTask.isImportant = updateTask.isImportant;
            existTask.description = updateTask.description;

            _taskService.UpdateTask(existTask);
            return Ok(new { message = "Tarea Actualizada con éxito.", data = existTask });
        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Debe de enviar un id");
            }
            _taskService.DeleteTask(id);
            return Ok(new { message = "Eliminado con exito." });
        }
    }
}
