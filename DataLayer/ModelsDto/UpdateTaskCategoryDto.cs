using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ModelsDto
{
  public class UpdateTaskCategoryDto
    {
        public int TaskCategortId { get; set; }

       
        public string CategoryName { get; set; }

        public bool IsDeleted { get; set; }

    
        public bool? Active { get; set; }
    }
}
