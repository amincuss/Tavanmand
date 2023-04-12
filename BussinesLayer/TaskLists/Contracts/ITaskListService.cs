using DataLayer.Models;
using DataLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.TaskLists.Contracts
{
   public interface ITaskListService
    {

        Task<List<TaskListDto>> GetAllTasks();
        Task<List<TaskListDto>> GetTaskListByTaskModeId(int taskModeId);

        TaskListDto GetTaskListById(int id);
        Task<(int StatusCode, string Message)> AddTask(AddTaskDto addTaskDto);
        Task<(int StatusCode, string Message)> UpdateTask(UpdateTaskDto updateTaskDto);
        Task<(int StatusCode, string Message)> DeleteTaskById(int taskListId);
        Task<(int StatusCode, string Message)> ChangeTaskMode(int taskModeId, int taskListId);
    }
}
