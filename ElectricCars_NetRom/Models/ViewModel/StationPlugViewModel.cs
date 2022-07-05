using ElectricCars_NetRom.Models.DB;
namespace ElectricCars_NetRom.Models.ViewModel

{
    public class StationPlugViewModel
    {
        public int StationId { get; set; }

        public IList<PlugType>? PlugTypes { get; set; }
        public int PlugTypeId { get; set; }




    }
}
