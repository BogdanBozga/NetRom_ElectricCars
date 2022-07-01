using System;
using System.Collections.Generic;

namespace ElectricCars_NetRom.Models.DB
{
    public partial class Station
    {
        public Station()
        {
            Plugs = new HashSet<Plug>();
        }
        

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string City { get; set; } = null!;

        public virtual ICollection<Plug> Plugs { get; set; }
    }
}
