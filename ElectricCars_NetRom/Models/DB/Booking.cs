using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectricCars_NetRom.Models.DB
{
    public partial class Booking
    {
        public Guid Id { get; set; }
        
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now + new TimeSpan(0,30,0);


        [Display(Name = "Car number")]
        public string CarNumber { get; set; } = null!;
        public int PlugId { get; set; }
        public Guid? UserId { get; set; }

        public virtual Plug Plug { get; set; } = null!;
        public virtual User? User { get; set; }




    }
}
