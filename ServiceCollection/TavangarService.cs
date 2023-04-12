using BussinesLayer.TaskCategorys.Contracts;
using BussinesLayer.TaskCategorys.Services;
using BussinesLayer.TaskLists.Contracts;
using BussinesLayer.TaskLists.Services;
using BussinesLayer.TaskModes.Contracts;
using BussinesLayer.TaskModes.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCollection
{
   public static class TavangarService
    {
        public static IServiceCollection TavangarServices(this IServiceCollection services)
        {

            services.AddScoped<ITaskListService, TaskListServices>();
            services.AddScoped<ITaskModeService, TaskModeService>();
            services.AddScoped<ITaskCategoryService, TaskCategoryService>();




            return services;
        }
    }
}
