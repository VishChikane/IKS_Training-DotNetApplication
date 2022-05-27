using Microsoft.EntityFrameworkCore;
using SampleApp.Entity.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleApp.Data.DataConnection
{
    public class SampleDbContext : DbContext
    {
        public SampleDbContext(DbContextOptions<SampleDbContext> options) : base(options)
        {
                
        }

        public DbSet<Teacher> teacherModel { get; set; }
    }
}
