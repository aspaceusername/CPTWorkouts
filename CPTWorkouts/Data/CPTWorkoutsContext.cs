using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CPTWorkouts.Models;

namespace CPTWorkouts.Data
{
    public class CPTWorkoutsContext : DbContext
    {
        public CPTWorkoutsContext (DbContextOptions<CPTWorkoutsContext> options)
            : base(options)
        {
        }

        public DbSet<CPTWorkouts.Models.Equipas> Equipas { get; set; } = default!;
    }
}
