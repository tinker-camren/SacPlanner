using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sacrament_Planner.Models;

namespace Sacrament_Planner.Models
{
    public class Sacrament_PlannerContext : DbContext
    {
        public Sacrament_PlannerContext (DbContextOptions<Sacrament_PlannerContext> options)
            : base(options)
        {
        }

        public DbSet<Sacrament_Planner.Models.Speaker> Speaker { get; set; }

        public DbSet<Sacrament_Planner.Models.Sacrament_Plan> Sacrament_Plan { get; set; }
    }
}
