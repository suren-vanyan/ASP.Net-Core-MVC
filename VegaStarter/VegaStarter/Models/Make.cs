using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace VegaStarter.Models
{
    public class Make
    {
       
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public ICollection<Model> Models { get; set; }

        public Make()
        {
                Models = new Collection<Model>();
        } 

    }
}