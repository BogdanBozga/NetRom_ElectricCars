using ElectricCars_NetRom.Models.DB;
using Microsoft.AspNetCore.Mvc;

namespace ElectricCars_NetRom.Controllers
{
    public class RechargingStationController : Controller
    {   
        private ElectricCars_NetRomContext _dbd;

        public RechargingStationController(ElectricCars_NetRomContext dbConn )
        {
            _dbd = dbConn;
        }


        public IActionResult Index()
        {
            return View(_dbd.Stations);
        }



    }
}
