using System;
using System.Collections.Generic;

namespace ElectricCars_NetRom.Models.DB
{
    public partial class Plug
    {
        public Plug()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public int StationId { get; set; }
        public int TypeId { get; set; }

        public virtual Station Station { get; set; } = null!;
        public virtual PlugType Type { get; set; } = null!;
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
