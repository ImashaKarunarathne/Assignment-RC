using Assignment.DTOs.Common;
using Assignment.DTOs.Task;
using Assignment.Interfaces;
using Assignment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository  _taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /*[HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetTasksByUserId([FromRoute]int userId)
        {
            var tasks = await _taskRepository.GetTasksByUserId(userId);

            if (tasks.Count() == 0)
            {
                return NotFound();
            }
            return Ok(tasks);
        }*/

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            var task = await _taskRepository.CreateTask(createTaskDto);
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _taskRepository.DeleteTask(id);

            if (task == null)
            {
                return NotFound();
            }
            return Ok("Task Deleted Successfully");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskFilterd(int id, [FromBody] FilterCriteria filterCriteria)
        {
            var task = await _taskRepository.FilterTask(id, filterCriteria);

            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

    }
}
