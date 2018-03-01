using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Driverr.Api.Models
{
    public class DrivrrContext : DbContext
    {
        public DrivrrContext(DbContextOptions<DrivrrContext> options)
            : base(options)
        {
        }

        public DbSet<State> States { get; set; }
        public DbSet<Suburb> Suburbs { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        
    }
}
