using BussinesLayer.TaskLists.Contracts;
using BussinesLayer.TaskLists.Services;
using DataLayer.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _taskListService;
        public TaskListController(ITaskListService  taskListService)
        {
        _taskListService = taskListService;


        }
        [HttpGet("GetAllTask")]
        public async Task<IActionResult> getAllTask()
        {

            var load = await _taskListService.GetAllTasks();

            return Ok(load);


        }
        [HttpGet("GetTaskById")]
        public IActionResult GetTaskById(int taskId)
        {

            var load =  _taskListService.GetTaskListById(taskId);

            return Ok(load);


        }
        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask(AddTaskDto addTaskDto)
        {

            var load = await _taskListService.AddTask(addTaskDto);

            return Ok(new { load.Message,load.StatusCode});


        }
        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto updateTaskDto)
        {

            var load = await _taskListService.UpdateTask(updateTaskDto);

            return Ok(new { load.Message, load.StatusCode });


        }
        [HttpDelete("DeleteTaskById")]
        public async Task<IActionResult> DeleteTaskById(int taskListId)
        {

            var load = await _taskListService.DeleteTaskById(taskListId);

            return Ok(new { load.Message, load.StatusCode });


        }
        [HttpGet("ChangeTaskMode")]
        public async Task<IActionResult> ChangeTaskMode(int taskId,int taskModeId)
        {

            var load = await _taskListService.ChangeTaskMode(taskModeId,taskId);

            return Ok(new { load.Message, load.StatusCode });


        }
        [HttpGet("GetTaskByTaskModeId")]
        public async Task<IActionResult> GetTaskListByTaskModeId(int taskModeId)
        {

            var load = await _taskListService.GetTaskListByTaskModeId(taskModeId);

            return Ok(load );


        }
    }
}
