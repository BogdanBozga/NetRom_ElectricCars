using System;
using System.Collections.Generic;

namespace ElectricCars_NetRom.Models.DB
{
    public partial class Booking
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CarNumber { get; set; } = null!;
        public int PlugId { get; set; }
        public Guid? UserId { get; set; }

        public virtual Plug Plug { get; set; } = null!;
        public virtual User? User { get; set; }
    }
}
