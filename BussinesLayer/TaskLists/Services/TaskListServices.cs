using BussinesLayer.TaskLists.Contracts;
using DataLayer.Models;
using DataLayer.ModelsDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.TaskLists.Services
{
   public class TaskListServices:ITaskListService
       
    {
        private readonly TavanmandContext _tavanmandContext;
        public TaskListServices( TavanmandContext tavanmandContext)
        {
            this._tavanmandContext = tavanmandContext;
        }

        public async Task<(int StatusCode, string Message)> AddTask(AddTaskDto addTaskDto)
        {
            try
            {
                if(addTaskDto == null)
                {

                    return (400, "Bad Request");
                }
                else
                {
                   await _tavanmandContext.TaskList.AddAsync(new TaskList
                    {
                   Title = addTaskDto.Title,
                    TaskCategoryId = addTaskDto.TaskCategoryId,
                         TaskModeId = addTaskDto.TaskModeId,
                         Active=true,
                         IsDeleted=false,
                         CreateDate = DateTime.Now,
                         

                    });
                 await   _tavanmandContext.SaveChangesAsync();
                    return (200, "Success");


                }


            }
            catch (Exception ex)
            {

                return (500, ex.Message);

            }
        }

        public async Task<(int StatusCode, string Message)> ChangeTaskMode(int taskModeId,int taskListId)
        {
            try
            {
  var load =await _tavanmandContext.TaskList.
                    Where(x => x.TaskListId == taskListId).SingleOrDefaultAsync();
                if(load == null)
                {
                    return (400, "fail");


                }
                else
                {
             load.TaskModeId= taskModeId;
            _tavanmandContext.TaskList.Update(load);
            await _tavanmandContext.SaveChangesAsync();
                return (200, "success");

                }
               

            } catch(Exception ex)
            {
                return (500, ex.Message);


            }
          

        }

        public async Task<(int StatusCode, string Message)> DeleteTaskById(int taskListId)
        {
            try
            {

  var del= await _tavanmandContext.TaskList.
                    Where(x=>x.TaskListId == taskListId).
                    SingleOrDefaultAsync();
                if(del != null)
                {
   del.IsDeleted = true;

            _tavanmandContext.TaskList.Update(del);
          await  _tavanmandContext.SaveChangesAsync();
                return (200, "Success");
                }
                else
                {

                    return (400, "id not found");
                }
         
            }catch(Exception ex)
            {


                return (500, ex.Message);
            }
          
        }

        public async Task<List<TaskListDto>> GetAllTasks()
        {
            try
            {
                var load = await _tavanmandContext.TaskList.Where(x=>x.Active==true && x.IsDeleted==false).Select(x=>
                new TaskListDto
                {
                    TaskListId=x.TaskListId, 
                    TaskCategoryId= x.TaskCategoryId,
                    TaskModeId=x.TaskModeId,
                    Title=x.Title,
                    CreateDate=x.CreateDate
                })
               .ToListAsync();
                 
                return load;

            }
            catch(Exception )
            {
                return null;

            }
        }

        public TaskListDto GetTaskListById(int taskId)
        {
            try
            {
                var load =  _tavanmandContext.TaskList.Where(x => x.Active == true && x.IsDeleted == false && x.TaskListId==taskId).Select(x =>
                 new TaskListDto
                 {
                     TaskListId = x.TaskListId,
                     TaskCategoryId = x.TaskCategoryId,
                     TaskModeId = x.TaskModeId,
                     Title = x.Title,
                     CreateDate = x.CreateDate
                 }).FirstOrDefault();
                

                return load;


            }
            catch(Exception e)
            {
                return null;

            }
        }

        public Task<List<TaskListDto>> GetTaskListByTaskModeId(int taskModeId)
        {
            try
            {
                var load = _tavanmandContext.TaskList.Where(x => x.Active == true && x.IsDeleted == false && x.TaskModeId == taskModeId).Select(x =>
                 new TaskListDto
                 {
                     TaskListId = x.TaskListId,
                     TaskCategoryId = x.TaskCategoryId,
                     TaskModeId = x.TaskModeId,
                     Title = x.Title,
                     CreateDate = x.CreateDate
                 }).ToListAsync();


                return load;


            }
            catch (Exception e)
            {
                return null;

            }
        }

        public async Task<(int StatusCode, string Message)> UpdateTask(UpdateTaskDto updateTaskDto)
        {
            try
            {
                _tavanmandContext.TaskList.Update(new TaskList
                {
                     Active = updateTaskDto.Active,
                        IsDeleted=updateTaskDto.IsDeleted,
                         TaskCategoryId= updateTaskDto.TaskCategoryId,
                          TaskListId= updateTaskDto.TaskListId,
                           TaskModeId= updateTaskDto.TaskModeId,
                            Title= updateTaskDto.Title,




                });
                await _tavanmandContext.SaveChangesAsync();
                return (200, "success");

            }catch(Exception e)
            {
                return (500, e.Message);


            }
        }
    }
}
