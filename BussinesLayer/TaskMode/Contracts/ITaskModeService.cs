using DataLayer.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.TaskModes.Contracts
{
   public interface ITaskModeService
    {
        Task<List<TaskModeDto>> GetAllTaskMode();

        TaskModeDto GetTaskModeById(int id);
        Task<(int StatusCode, string Message)> AddTaskMode(string taskModeName);
        Task<(int StatusCode, string Message)> UpdateTaskMode(UpdateTaskModeDto taskModeDto);
        Task<(int StatusCode, string Message)> DeleteTaskModeById(int taskModeId);
    }
}
