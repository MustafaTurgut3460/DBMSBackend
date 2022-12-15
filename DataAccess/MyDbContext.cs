using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string connString = "Server=localhost; User=root; Password=zeynep12345; Database=VTProject";

            optionsBuilder.UseMySql(connString, ServerVersion.AutoDetect(connString));
        }

        public DbSet<Employee> Employees {get; set;}
        public DbSet<Station> Stations { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Service> Services { get; set; }
    }
}