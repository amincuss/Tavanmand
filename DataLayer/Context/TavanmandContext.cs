﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models;

public partial class TavanmandContext : DbContext
{
    public TavanmandContext(DbContextOptions<TavanmandContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskCategory> TaskCategory { get; set; }

    public virtual DbSet<TaskList> TaskList { get; set; }

    public virtual DbSet<TaskMode> TaskMode { get; set; }

  
}