using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks_API.Models.Domain;
using NZWalks_API.Models.DTO;
using NZWalks_API.Repositories;

namespace NZWalks_API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper) 
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync();

            // return DTO regions
            ////var regionsDTO = new List<Models.DTO.Region>();
            ////regions.ToList().ForEach(region => 
            ////{
            ////    var regionDTO = new Models.DTO.Region()
            ////    {
            ////        Id= region.Id,
            ////        Code= region.Code,
            ////        Name= region.Name,
            ////        Area= region.Area,
            ////        Lat= region.Lat,
            ////        Long= region.Long,
            ////        Population= region.Population,

            ////    };

            ////    regionsDTO.Add(regionDTO);
            ////});

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            // Get region from Database
            var region = await regionRepository.GetAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Models.DTO.Region>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            // Request(DTO) to Domain model
            var region = new Models.Domain.Region
            {

                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population,
            };

            //Pass details to Repository
            region = await regionRepository.AddAsync(region);

            //Convert back to DTO

            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population

            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegoionAsync(Guid id)
        {
            //Get Region from Database
            var region = await regionRepository.DeleteAsync(id);

            //If null found
            if (region == null)
            {
                return NotFound();
            }

            //Convert response back to DTO

            // var regionDTO = mapper.Map<Models.DTO.Region>(region);
            var regionDTO = new Models.DTO.Region
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Population = region.Population
            };

            // return Ok response
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateRegionRequest updateRegionRequest)
        {
            // Convert DTO to Domain Model

            var Region = new Models.Domain.Region
            {
                Code= updateRegionRequest.Code,
                Name= updateRegionRequest.Name, 
                Area= updateRegionRequest.Area,
                Lat= updateRegionRequest.Lat,
                Long= updateRegionRequest.Long,
                Population= updateRegionRequest.Population
            };

            //Update region using Repository

            var updateRegion = await regionRepository.UpdateAsync(id, Region);

            //If null then NotFound

            if (updateRegion == null)
            {
                return NotFound();
            }

            //Convert Domain back to DTO

            var regionDTO = new Models.DTO.Region
            {
                Id = updateRegion.Id,
                Code = updateRegion.Code,
                Name = updateRegion.Name,
                Area = updateRegion.Area,
                Lat = updateRegion.Lat,
                Long = updateRegion.Long,
                Population = updateRegion.Population
            };

            // Return OK Response
            return Ok(regionDTO);
        }
    }
}
