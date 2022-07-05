using Microsoft.AspNetCore.Mvc;
using ElectricCars_NetRom.Models.ViewModel;
using ElectricCars_NetRom.Models.DB;


namespace ElectricCars_NetRom.Controllers
{
    public class AddControler : Controller
    {
        private ElectricCars_NetRomContext _changingStationContext = null;
        private StationPlugViewModel _stationPlugViewModel;

        public AddControler(ElectricCars_NetRomContext dbConn)
        {
            _changingStationContext = dbConn;
        }
        public IActionResult Index(int stationId)
        {
            _stationPlugViewModel.StationId = stationId;
            return View();
        }

        public IActionResult Add()
        {
          
            return View();
        }


    }
}
