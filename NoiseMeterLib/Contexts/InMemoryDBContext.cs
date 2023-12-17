using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoiseMeterLib.Models;

namespace NoiseMeterLib.Contexts
{
    public class InMemoryDBContext:DbContext
    {
        public InMemoryDBContext(DbContextOptions<InMemoryDBContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData
                (
                    new User
                    {
                        Id = 1,
                        Name = "Administrator 1",
                        Username = "Admin",
                        Password = "Admin"
                    }
                
                );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {

           builder.UseInMemoryDatabase(databaseName: "InMemory");      
        
        }
        public DbSet<NoiseMeter> NoiseMeters { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
