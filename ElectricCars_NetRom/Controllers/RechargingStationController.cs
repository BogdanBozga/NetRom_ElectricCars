using ElectricCars_NetRom.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectricCars_NetRom.Models.ViewModel;



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

        public IActionResult Map(int Id)
        {
            Station station = _changingStationContext.Stations.FirstOrDefault(m => m.Id == Id);
            string city = station.City;
            string address = station.Adress;
            string name = station.Name;
            name = name.Replace(" ", "+");
            name = name.Replace(",", "%2C");
            address = address.Replace(" ", "+");
            address = address.Replace(",", "%2C");
            string url = "https://www.google.com/maps/search/?api=1&query=";
            url = url + name+ "+" + city + "+" + address;
            Console.WriteLine(url);
            Response.Redirect(url);
            return RedirectToAction("Index");
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
            Station newStation = new Station();
            newStation.Name = StationInstance.Name;
            newStation.City = StationInstance.City;
            newStation.Adress = StationInstance.Adress;
            _changingStationContext.Add(newStation);
            _changingStationContext.SaveChanges();

            return RedirectToAction("Index");
        }


        private StationPlugViewModel stationPlugViewModel = new StationPlugViewModel();
        public ActionResult AddPlug(int id)
        {
            stationPlugViewModel.StationId = id;
            stationPlugViewModel.PlugTypes = _changingStationContext.PlugTypes.ToList();
            return View(stationPlugViewModel);
        }

        [HttpPost]
        [ActionName("SavePlug")]
        public IActionResult SavePlug(StationPlugViewModel spModel)
        {
            Plug newPlug = new Plug();
            newPlug.StationId = spModel.StationId;
            newPlug.TypeId = spModel.PlugTypeId;
            _changingStationContext.Add(newPlug);
            _changingStationContext.SaveChanges();

            return RedirectToAction("Index");
        }



    }
}
