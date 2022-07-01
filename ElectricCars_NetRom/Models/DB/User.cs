using System;
using System.Collections.Generic;

namespace ElectricCars_NetRom.Models.DB
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPassword { get; set; } = null!;
        public string UserEmail { get; set; } = null!;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
