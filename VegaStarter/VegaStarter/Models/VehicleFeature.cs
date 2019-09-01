using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VegaStarter.Models
{
    [Table("VehicleFeatures"))]
    public class VehicleFeature
    {
            
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}
