using ElectricCars_NetRom.Models.DB;

namespace ElectricCars_NetRom.Models.ViewModel
{
    public class BookingAndTimes
    {
        public int PlugId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now + new TimeSpan(0, 1, 0);
        public DateTime EndDate { get; set; } = DateTime.Now + new TimeSpan(0, 31, 0);

        public string CarNumber { get; set; } = null!;
        public List<StartEndTime>? bookedTimes { get; set; }


    }
}
