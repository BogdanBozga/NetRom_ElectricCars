using ElectricCars_NetRom.Models.DB;

namespace ElectricCars_NetRom.Models.ViewModel
{
    public class BookingAndTimes
    {
        public int PlugId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string CarNumber { get; set; } = null!;
        public List<StartEndTime>? BookedTimes { get; set; }


    }
}
