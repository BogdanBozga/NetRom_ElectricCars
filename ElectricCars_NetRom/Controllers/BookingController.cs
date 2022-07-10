using ElectricCars_NetRom.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectricCars_NetRom.Models.ViewModel;

namespace ElectricCars_NetRom.Controllers
{
    public class BookingController : Controller
    {


        private ElectricCars_NetRomContext _Context;

        public BookingController(ElectricCars_NetRomContext dbConn)
        {
            _Context = dbConn;
        }


        public IActionResult Index(int Id)
        {
            Booking booking = new Booking();
            booking.PlugId = Id;
            return View(booking);
        }


        [HttpPost]
        [ActionName("SaveBooking")]
        public IActionResult SaveBoooking(Booking booking)
        {
                ModelState.Clear();
                if (booking.StartDate > booking.EndDate)
                {
                    ModelState.AddModelError(nameof(Booking.StartDate), "Start date can't be after end date");
                } 
                if( booking.StartDate < DateTime.Now+new TimeSpan(0,1,0))
                {
                    ModelState.AddModelError(nameof(Booking.StartDate), "Start date can't be in the past");
                }
                if(booking.StartDate + new TimeSpan(0,29,0) > booking.EndDate)
                {
                    ModelState.AddModelError(nameof(Booking.EndDate), "Minimal recharging time is 30 minutes");
                }
                if(ModelState.IsValid){
                    Booking newBookingSave = new Booking();
                    newBookingSave.StartDate = booking.StartDate;
                    newBookingSave.EndDate = booking.EndDate;
                    newBookingSave.CarNumber = booking.CarNumber;
                    newBookingSave.PlugId = booking.PlugId;
                    newBookingSave.Plug = _Context.Plugs.First(x => x.Id == booking.PlugId);
                    _Context.Add(newBookingSave);
                    _Context.SaveChanges();
                    return RedirectToAction("Details", "RechargingStation",new {id = _Context.Plugs.First(m => m.Id == booking.PlugId).StationId});
                }
                else
                {
                    return View("Index", booking);
                }

        }
    }
}
