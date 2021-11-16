using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListTasks.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ListTasks.Context
{
    public class AppDbContext : DbContext
    {
       public AppDbContext(DbContextOptions<AppDbContext> option)
            : base(option)
        {

        }

        public DbSet<TasksModels> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true)
                .Build();

            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ServerConnection"));
                
        }
        
       
    }
}
