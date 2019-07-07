using System.ComponentModel.DataAnnotations;

namespace VegaStarter.Models
{
    public class Feature
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}