﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ModelsDto
{
    public class UpdateTaskDto
    {
        public int TaskListId { get; set; }

        public int TaskCategoryId { get; set; }

        public DateTime CreateDate { get; set; }

        public int TaskModeId { get; set; }

      
        public string Title { get; set; }

        public bool IsDeleted { get; set; }

        public bool? Active { get; set; }
    }
}
