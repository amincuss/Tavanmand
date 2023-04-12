using BussinesLayer.TaskLists.Contracts;
using BussinesLayer.TaskLists.Services;
using BussinesLayer.TaskModes.Contracts;
using DataLayer.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskModeController : ControllerBase
    {
        private readonly ITaskModeService  _taskModeService;
        public TaskModeController(ITaskModeService taskModeService)
        {
         _taskModeService = taskModeService;


        }
        [HttpGet("GetAllTaskMode")]
        public async Task<IActionResult> getAllTask()
        {

            var load = await _taskModeService.GetAllTaskMode();

            return Ok(load);


        }
        [HttpGet("GetTaskModeById")]
        public IActionResult GetTaskById(int taskModeId)
        {

            var load = _taskModeService.GetTaskModeById(taskModeId);

            return Ok(load);


        }
        [HttpGet("AddTaskMode")]
        public async Task<IActionResult> AddTask(string TaskModeName)
        {

            var load = await _taskModeService.AddTaskMode(TaskModeName);

            return Ok(new { load.Message, load.StatusCode });


        }
        [HttpPut("UpdateTaskMode")]
        public async Task<IActionResult> UpdateTask(UpdateTaskModeDto updateTaskModeDto )
        {

            var load = await _taskModeService.UpdateTaskMode(updateTaskModeDto);

            return Ok(new { load.Message, load.StatusCode });


        }
        [HttpDelete("DeleteTaskModeById")]
        public async Task<IActionResult> DeleteTaskById(int taskModeId)
        {

            var load = await _taskModeService.DeleteTaskModeById(taskModeId);

            return Ok(new { load.Message, load.StatusCode });


        }

    }
}
