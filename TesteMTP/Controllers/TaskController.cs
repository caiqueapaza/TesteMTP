using Microsoft.AspNetCore.Mvc;
using TesteMTP.Model;
using TesteMTP.Service;

namespace TesteMTP.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskInterface _taskInterface;

        public TaskController(ITaskInterface taskInterface)
        {
            _taskInterface = taskInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TaskModel>>>> GetTasks()
        {
            return Ok(await _taskInterface.GetTasks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TaskModel>>> GetTaskById(int id)
        {
            ServiceResponse<TaskModel> sericeResponse = await _taskInterface.GetTaskById(id);
            
            return Ok(sericeResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TaskModel>>>> CreateNewTask(TaskModel newTask)
        {
            return Ok(await _taskInterface.CreateNewTask(newTask));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TaskModel>>>> UpdateTask(TaskModel alterTask)
        {
            ServiceResponse<List<TaskModel>> serviceResponse = await _taskInterface.UpdateTask(alterTask);

            return Ok(serviceResponse);
        }
        [HttpPut("finishTask")]
        public async Task<ActionResult<ServiceResponse<List<TaskModel>>>> FinishTask(int id)
        {
            ServiceResponse<List<TaskModel>> serviceResponse = await _taskInterface.FinishTask(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<TaskModel>>>> DeleteTask(int id)
        {
            ServiceResponse<List<TaskModel>> serviceResponse = await _taskInterface.DeleteTask(id);

            return Ok(serviceResponse);
        }
    }
}
