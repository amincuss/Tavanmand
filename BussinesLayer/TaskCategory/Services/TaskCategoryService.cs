using BussinesLayer.TaskCategorys.Contracts;
using DataLayer.Models;
using DataLayer.ModelsDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.TaskCategorys.Services
{
    public class TaskCategoryService : ITaskCategoryService
    {
        private readonly TavanmandContext _tavanmandContext;
        public TaskCategoryService(TavanmandContext tavanmandContext)
        {
            this._tavanmandContext = tavanmandContext;
        }
        public async Task<(int StatusCode, string Message)> AddTaskCategory(string taskCategoryName)
        {
            try
            {
                if (taskCategoryName == null)
                {

                    return (400, "Bad Request");
                }
                else
                {
                    await _tavanmandContext.TaskCategory.AddAsync(new TaskCategory
                    {
                        CategoryName = taskCategoryName,
                         Active = true,
                          IsDeleted = false,
                           


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

        public async Task<(int StatusCode, string Message)> DeleteTaskCategoryById(int taskCategoryId)
        {
            try
            {

                var del = await _tavanmandContext.TaskCategory.
                                  Where(x => x.TaskCategortId == taskCategoryId).SingleOrDefaultAsync();

                if (del != null)
                {
                    del.IsDeleted = true;

                    _tavanmandContext.TaskCategory.Update(del);
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

        public async Task<List<TaskCategoryDto>> GetAllTaskCategory()
        {
            try
            {
                var load = await _tavanmandContext.TaskCategory.Where(x => x.Active == true && x.IsDeleted == false).Select(x =>
                new TaskCategoryDto
                {
                    CategoryName = x.CategoryName,
                    TaskCategortId = x.TaskCategortId
                }).ToListAsync();
              

                return load;

            }
            catch (Exception)
            {
                return null;

            }
        }

        public TaskCategoryDto GetTaskCategoryById(int id)
        {
            try
            {
                var load = _tavanmandContext.TaskCategory.Where(x => x.Active == true && x.IsDeleted == false && x.TaskCategortId == id).Select(x =>
                 new TaskCategoryDto
                 {
                      CategoryName= x.CategoryName,
                       TaskCategortId=x.TaskCategortId
                 }).FirstOrDefault();


                return load;


            }
            catch (Exception e)
            {
                return null;

            }
        }

        public async Task<(int StatusCode, string Message)> UpdateTaskCategory(UpdateTaskCategoryDto updateTaskCategoryDto)
        {
            try
            {
                _tavanmandContext.TaskCategory.Update(new TaskCategory
                {
                    CategoryName= updateTaskCategoryDto.CategoryName,
                     IsDeleted= updateTaskCategoryDto.IsDeleted,
                      Active   = updateTaskCategoryDto.Active,
                       TaskCategortId = updateTaskCategoryDto.TaskCategortId





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
