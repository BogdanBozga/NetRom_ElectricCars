using ElectricCars_NetRom.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var station = _changingStationContext.Stations
                .Include(x => x.Plugs)
                .ThenInclude(x => x.Type)
                .FirstOrDefault(s => s.Id == id);

            return View(station);
        }



        public IActionResult Booking(int id)
        {
            return View();
        }


        public IActionResult DeleteStation(int id)
        {
            _changingStationContext.Remove(_changingStationContext.Stations.Single(s => s.Id == id));
            _changingStationContext.SaveChanges();
            return RedirectToAction("Index", "RechargingStation");
        }

        public IActionResult DeletePlug(int id)
        {
            _changingStationContext.Remove(_changingStationContext.Plugs.Single(s => s.Id == id));
            _changingStationContext.SaveChanges();
            return RedirectToAction("Index", "RechargingStation");
        }


        public IActionResult AddStation()
        {
            return View();
        }

        [HttpPost]
        [ActionName("SaveStation")]
        public IActionResult SaveStation(Station StationInstance)
        { 

            //if(StationInstance.Name == null || StationInstance.City == null || StationInstance.Adress == null)
            
                
            

            Station newStation = new Station();
            newStation.Name = StationInstance.Name;
            newStation.City = StationInstance.City;
            newStation.Adress = StationInstance.Adress;
            _changingStationContext.Add(newStation);
            _changingStationContext.SaveChanges();

            return RedirectToAction("Index", "RechargingStation");
        }


        public IActionResult AddPlug(int idStation)
        {
            return RedirectToAction("Index", "RechargingStation");
        }

    }
}
