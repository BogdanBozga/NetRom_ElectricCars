using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectricCars_NetRom.Models.DB
{
    public partial class Station
    {
        public Station()
        {
            Plugs = new HashSet<Plug>();
        }
        

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Adress { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;

        public virtual ICollection<Plug> Plugs { get; set; }
    }
}
