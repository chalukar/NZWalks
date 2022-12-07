using Microsoft.EntityFrameworkCore;
using NZWalks_API.Models.Domain;

namespace NZWalks_API.Data
{
    public class NZWalksDbContext:DbContext
    {
        //-----Create a Constructor-----//
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext>options):base(options)
        {

        }

        //create a properties
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficalty> WalkDifficalty { get; set; }

    }
}
