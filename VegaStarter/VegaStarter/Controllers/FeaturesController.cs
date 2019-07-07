using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VegaStarter.Models;
using VegaStarter.Models.Resources;
using VegaStarter.Persistence;

namespace VegaStarter.Controllers
{
    [Route("api/[controller]")]
    public class FeaturesController
    {
        private readonly IMapper mapper;
        private readonly VegaDbContext context;

        public FeaturesController(IMapper mapper,VegaDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("all-features")]
        public async Task<IEnumerable<FeatureResource>> GetFeatures(){
            var features= await context.Features.ToListAsync();
           var featureResource= mapper.Map<List<Feature>,List<FeatureResource>>(features);
            return featureResource;
        }
    }
}