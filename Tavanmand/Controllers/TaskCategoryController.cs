using BussinesLayer.TaskCategorys.Contracts;
using DataLayer.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskCategoryController : ControllerBase
    {
        private readonly ITaskCategoryService _taskCategoryService;
      public TaskCategoryController(ITaskCategoryService taskCategoryService)
        {

             _taskCategoryService = taskCategoryService;

        }
        [HttpGet("GetAllTaskCategory")]
        public async Task<IActionResult> getAllTaskCategory()
        {

            var load = await _taskCategoryService.GetAllTaskCategory();

            return Ok(load);


        }
        [HttpGet("GetTaskCategoryById")]
        public IActionResult GetTaskById(int taskCategoryId)
        {

            var load = _taskCategoryService.GetTaskCategoryById(taskCategoryId);

            return Ok(load);


        }
        [HttpGet("AddTaskCategory")]
        public async Task<IActionResult> AddTask(string TaskCategoryName)
        {

            var load = await _taskCategoryService.AddTaskCategory(TaskCategoryName);

            return Ok(new { load.Message, load.StatusCode });


        }
        [HttpPut("UpdateTaskCategory")]
        public async Task<IActionResult> UpdateTask(UpdateTaskCategoryDto updateTaskCategoryDto)
        {

            var load = await _taskCategoryService.UpdateTaskCategory(updateTaskCategoryDto);

            return Ok(new { load.Message, load.StatusCode });


        }
        [HttpDelete("DeleteTaskCategoryById")]
        public async Task<IActionResult> DeleteTaskById(int taskCategoryId)
        {

            var load = await _taskCategoryService.DeleteTaskCategoryById(taskCategoryId);

            return Ok(new { load.Message, load.StatusCode });


        }
    }
}
