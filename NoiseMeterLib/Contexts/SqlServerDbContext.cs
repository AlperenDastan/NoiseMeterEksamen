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
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options) : base(options)
        {

        }

        public DbSet<NoiseMeter> NoiseMeters { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
