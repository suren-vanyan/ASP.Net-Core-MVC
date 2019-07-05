using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegaStarter.Models;

namespace VegaStarter.Mapping
{
    public class MapperConfig
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(conf =>
              {
                  conf.CreateMap<Make, MakeResource>();
                  conf.CreateMap<Make, MakeResource>().ReverseMap();
                  conf.CreateMap<Model, ModelResource>();
                  conf.CreateMap<Model, ModelResource>().ReverseMap();
              });

            return mapperConfig.CreateMapper();
        }
    }
}
