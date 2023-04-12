using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ModelsDto
{
   public class AddTaskDto
    {
        public int TaskCategoryId { get; set; }


        public int TaskModeId { get; set; }

      
        public string Title { get; set; }

    }
}
