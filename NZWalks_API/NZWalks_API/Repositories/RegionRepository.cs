using Microsoft.EntityFrameworkCore;
using NZWalks_API.Data;
using NZWalks_API.Models.Domain;

namespace NZWalks_API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext nZWalksDbContext;

        //Constructor
        public RegionRepository(NZWalksDbContext nZWalksDbContext) 
        {
            this.nZWalksDbContext = nZWalksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id= Guid.NewGuid();
            await nZWalksDbContext.Regions.AddAsync(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;

        }
        // Delete
        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null) {
                return null;
            }
            // Delete the Region
            nZWalksDbContext.Regions.Remove(region);
            await nZWalksDbContext.SaveChangesAsync();
            return region;
        }

        //Get All
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nZWalksDbContext.Regions.ToListAsync();
        }

        //Get One Record
        public async Task<Region> GetAsync(Guid id)
        {
            return await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

        }
        // Update
        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingregion = await nZWalksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingregion == null)
            {
                return null;
            }

            existingregion.Code= region.Code;
            existingregion.Name= region.Name;
            existingregion.Area= region.Area;
            existingregion.Lat= region.Lat;
            existingregion.Long= region.Long;
            existingregion.Population= region.Population;

            await nZWalksDbContext.SaveChangesAsync();
            return existingregion;
        }

        

    }
}
