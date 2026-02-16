using EntityManagementAspNet.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityManagementAspNet.DataAccess.Concrete.EntityFramework
{
    public class MyContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //localhost:5432/entity_management
            optionsBuilder.UseNpgsql(
         "Host=localhost;Port=5432;Database=asp_entity_management;Username=postgres;Password=123456");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("people");
            modelBuilder.Entity<Log>().ToTable("logs");
            modelBuilder.Entity<WebServiceOperation>().ToTable("web_service_operations");
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<WebServiceOperation> WebServiceOperations { get; set; }
    }
}