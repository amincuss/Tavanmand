using DataLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.TaskCategorys.Contracts
{
    public interface ITaskCategoryService
    {
        Task<List<TaskCategoryDto>> GetAllTaskCategory();

        TaskCategoryDto GetTaskCategoryById(int id);
        Task<(int StatusCode, string Message)> AddTaskCategory(string taskCategoryName);
        Task<(int StatusCode, string Message)> UpdateTaskCategory(UpdateTaskCategoryDto updateTaskCategoryDto);
        Task<(int StatusCode, string Message)> DeleteTaskCategoryById(int taskCategoryId);
    }
}
