using Microsoft.EntityFrameworkCore;
using NoiseMeterLib.Contexts;
using NoiseMeterLib.Models;

namespace NoiseMeterRestApi
{
    public class Testcontext : DbContext
    {
        public Testcontext(DbContextOptions<Testcontext> options)
        : base(options)
        {
        }

        public DbSet<NoiseMeter> NoiseMeters { get; set; }
    }
}
