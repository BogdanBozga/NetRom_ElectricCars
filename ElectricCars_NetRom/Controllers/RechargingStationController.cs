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

            if (station != null)
            {
                IEnumerable<StationAndPlugType> model;
                model = (from s in _changingStationContext.Set<Station>().Where(s => s.Id == id)
                         join p in _changingStationContext.Set<Plug>() on s.Id equals p.StationId
                         join t in _changingStationContext.Set<PlugType>() on p.TypeId equals t.Id
                         select new StationAndPlugType
                         {
                             StationId = s.Id,
                             StationName = s.Name,
                             StationAdress = s.Adress,
                             StationCity = s.City,
                             PlugTypeName = t.Name,
                             PlugId = p.Id
                         }
                             ).ToList();
                return View(model);
            }
            return RedirectToAction("Index", "RechargingStation");
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
    }
}
