using BussinesLayer.TaskModes.Contracts;
using DataLayer.Models;
using DataLayer.ModelsDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.TaskModes.Services
{
    public class TaskModeService : ITaskModeService
    {
        private readonly TavanmandContext _tavanmandContext;
        public TaskModeService(TavanmandContext tavanmandContext)
        {
            this._tavanmandContext = tavanmandContext;
        }
        public async Task<(int StatusCode, string Message)> AddTaskMode(string taskModeName)
        {
            try
            {
                if (taskModeName == null)
                {

                    return (400, "Bad Request");
                }
                else
                {
                    await _tavanmandContext.TaskMode.AddAsync(new TaskMode
                    {
                      Title = taskModeName,


                    });
                    await _tavanmandContext.SaveChangesAsync();
                    return (200, "Success");


                }


            }
            catch (Exception ex)
            {

                return (500, ex.Message);

            }
        }

        public async Task<(int StatusCode, string Message)> DeleteTaskModeById(int taskModeId)
        {
            try
            {

                var del = await _tavanmandContext.TaskMode.
                                  Where(x => x.TaskModeId == taskModeId).SingleOrDefaultAsync();
                                 
                if (del != null)
                {
                    del.IsDeleted = true;

                    _tavanmandContext.TaskMode.Update(del);
                    await _tavanmandContext.SaveChangesAsync();
                    return (200, "Success");
                }
                else
                {

                    return (400, "id not found");
                }

            }
            catch (Exception ex)
            {


                return (500, ex.Message);
            }
        }

        public async Task<List<TaskModeDto>> GetAllTaskMode()
        {
            try
            {
                var load = await _tavanmandContext.TaskMode.Where(x => x.Active == true && x.IsDeleted == false).Select(x =>
                new TaskModeDto
                {
                    Title = x.Title,
                    TaskModeId = x.TaskModeId,
                })
               .ToListAsync();

                return load;

            }
            catch (Exception)
            {
                return null;

            }
        }

        public TaskModeDto GetTaskModeById(int id)
        {
            try
            {
                var load = _tavanmandContext.TaskMode.Where(x => x.Active == true && x.IsDeleted == false && x.TaskModeId == id).Select(x =>
                 new TaskModeDto
                 {
                     Title= x.Title,
                     TaskModeId = x.TaskModeId,
                 }).FirstOrDefault();


                return load;


            }
            catch (Exception e)
            {
                return null;

            }
        }

        public async Task<(int StatusCode, string Message)> UpdateTaskMode(UpdateTaskModeDto taskModeDto)
        {
            try
            {
                _tavanmandContext.TaskMode.Update(new TaskMode
                {
                    TaskModeId= taskModeDto.TaskModeId, 
                    Title= taskModeDto.Title,   
                   Active = taskModeDto.Active,
                    IsDeleted = taskModeDto.IsDeleted,




                });
                await _tavanmandContext.SaveChangesAsync();
                return (200, "success");

            }
            catch (Exception e)
            {
                return (500, e.Message);


            }
        }
    }
}
