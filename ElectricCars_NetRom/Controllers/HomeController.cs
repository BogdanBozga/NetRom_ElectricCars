using System.Diagnostics;
using ElectricCars_NetRom.Models;
using Microsoft.AspNetCore.Mvc;
using ElectricCars_NetRom.Models.DB;
using ElectricCars_NetRom.Models.ViewModel;

namespace ElectricCars_NetRom.Controllers
{
    public class HomeController : Controller
    {
        private ElectricCars_NetRomContext _Context;

        public HomeController(ElectricCars_NetRomContext dbConn)
        {
            _Context = dbConn;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public ActionResult Index()
        //{
        //    List<Station> StationInstance = _Context.Stations.ToList();


        //    List<string> stationNames = new List<string>();
        //    List<string> percentages = new List<string>();
        //    foreach (var item in StationInstance)
        //    {

        //        double stationPercentage = 0;
        //        stationNames.Add(item.Name);
        //        List<Plug> Plugs = _Context.Plugs.Where(m => m.StationId == item.Id).ToList();
        //        foreach (Plug plug in Plugs)
        //        {
        //            List<Booking> BookingsInstance = _Context.Bookings.Where(m => m.PlugId == plug.Id
        //                                                                        && m.StartDate.Date >= DateTime.Now.Date
        //                                                                        && m.EndDate.Date <= DateTime.Now.AddDays(7)).ToList();
        //            double TotalBookedTime = 0;
        //            foreach (Booking booking in BookingsInstance)
        //            {
        //                TimeSpan aux = booking.EndDate - booking.StartDate;
        //                TotalBookedTime += aux.TotalMinutes;
        //            }
        //            stationPercentage += TotalBookedTime / (DateTime.Now.AddDays(7).Date - DateTime.Now.Date).TotalMinutes;
        //        }
        //        stationNames.Add(item.Name.ToString());
        //        percentages.Add(stationPercentage.ToString("0.00"));
        //    }
        //    TempData["stationNames"] = string.Join(",", stationNames);
        //    TempData["percentage"] = string.Join(",", percentages);
        //    return View();
        //}

        //public IActionResult Index()
        //{
        //    Statistics StatistcsIntance = new Statistics();
        //    List<Station> StationInstance = _Context.Stations.ToList();
        //    StatistcsIntance.StationStatistic = new List<StationStatistics>();

        //    foreach (Station stat in StationInstance)
        //    {
        //        StationStatistics stationStatistics = new StationStatistics();
        //        stationStatistics.StationName = stat.Name;
        //        stationStatistics.OcupationPercentage = 0;

        //        List<Plug> Plugs = _Context.Plugs.Where(m => m.StationId == stat.Id).ToList();
        //        foreach (Plug plug in Plugs)
        //        {
        //            List<Booking> BookingsInstance = _Context.Bookings.Where(m => m.PlugId == plug.Id
        //                                                                        && m.StartDate.Date >= DateTime.Now.Date
        //                                                                        && m.EndDate.Date <= DateTime.Now.AddDays(7)).ToList();
        //            double TotalBookedTime = 0;

        //            foreach (Booking booking in BookingsInstance)
        //            {

        //                TimeSpan aux = booking.EndDate - booking.StartDate;
        //                TotalBookedTime += aux.TotalMinutes;
        //            }

        //            stationStatistics.OcupationPercentage += TotalBookedTime / (DateTime.Now.AddDays(7).Date - DateTime.Now.Date).TotalMinutes;
        //        }
        //        StatistcsIntance.StationStatistic.Add(stationStatistics);
        //    }
        //    return View(StatistcsIntance);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}