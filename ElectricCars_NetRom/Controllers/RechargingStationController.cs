using ElectricCars_NetRom.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace ElectricCars_NetRom.Controllers
{
    public class RechargingStationController : Controller
    {   
        private ElectricCars_NetRomContext _changingStationContext;

        public RechargingStationController(ElectricCars_NetRomContext dbConn )
        {
            _changingStationContext = dbConn;
        }


        public IActionResult Index()
        {
            return View(_changingStationContext.Stations);
        }

        public IActionResult Details(int id)
        {
            var station = _changingStationContext.Stations.FirstOrDefault(s => s.Id == id);

            return View(station);
        }


    }
}
