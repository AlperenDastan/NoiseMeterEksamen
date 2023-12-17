using Microsoft.EntityFrameworkCore;
using NoiseMeterLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseMeterLib.Contexts
{
    public class SqlServerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=tcp:mssql-server-100k-free.database.windows.net,1433;Initial Catalog=NoiseMeterDb;Persist Security Info=False;User ID=msssql;Password=Qgn45wtc!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public DbSet<NoiseMeter> NoiseMeters { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
