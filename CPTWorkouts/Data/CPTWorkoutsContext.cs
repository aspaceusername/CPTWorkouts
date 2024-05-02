using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CPTWorkouts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace CPTWorkouts.Data
{
    public class CPTWorkoutsContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        /// <summary>
        /// 'database' of our application
        /// </summary>
        /// <param name="options"></param>
        public CPTWorkoutsContext (DbContextOptions<CPTWorkoutsContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // builder.Entity<IdentityUser>().HasData()
        }

        public DbSet<Equipas> Equipas { get; set; }
        public DbSet<Aulas> Aulas { get; set; }
        public DbSet<Clientes> Clientes { get; set;}
        public DbSet<Compram> Compram { get; set; }
        public DbSet<Faturas> Faturas { get; set;}
        public DbSet<Inscrevem_se> Inscrevem_se { get; set; }
        public DbSet<Pertencem> Pertencem { get; set;}
        public DbSet<Serviços> Serviços { get; set; }
        public DbSet<Treinadores> Treinadores { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
