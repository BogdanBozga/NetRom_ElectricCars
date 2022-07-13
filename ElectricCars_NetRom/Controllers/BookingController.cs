using ElectricCars_NetRom.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ElectricCars_NetRom.Models.ViewModel;
using System.Text.RegularExpressions;

namespace ElectricCars_NetRom.Controllers
{
    public class BookingController : Controller
    {


        private ElectricCars_NetRomContext _Context;

        public BookingController(ElectricCars_NetRomContext dbConn)
        {
            _Context = dbConn;
        }

        private static List<StartEndTime> bookingTimesVariable;
        public IActionResult Index(int Id)
        {
            bookingTimesVariable = new List<StartEndTime>();
            BookingAndTimes specialBooking = new BookingAndTimes();
            specialBooking.PlugId = Id;
            specialBooking.StartDate = DateTime.Now + new TimeSpan(0, 1, 0);
            specialBooking.EndDate = DateTime.Now + new TimeSpan(0, 31, 0);
            specialBooking.BookedTimes = new List<StartEndTime> { new StartEndTime() };
            List<Booking> bookings = _Context.Bookings.Where(m => m.PlugId == Id && m.StartDate.Date >= DateTime.Now.Date).ToList();
            //List<Booking> bookings = _Context.Bookings.Where(m => m.PlugId == Id && m.StartDate.Date >= DateTime.Now.Date).OrderBy(m => m.StartDate).ToList();

            foreach (Booking b in bookings)
            {
                StartEndTime aux = new StartEndTime();
                aux.startTime = b.StartDate;
                aux.endTime = b.EndDate;
                bookingTimesVariable.Add(aux);
            }
            specialBooking.BookedTimes = bookingTimesVariable;
            return View(specialBooking);
        }


        [HttpPost]
        [ActionName("SaveBooking")]
        public IActionResult SaveBoooking(BookingAndTimes booking)
        {
            booking.BookedTimes = bookingTimesVariable;
            ModelState.Clear();
            if (booking.StartDate > booking.EndDate)
            {
                ModelState.AddModelError(nameof(Booking.StartDate), "Start date can't be after end date");
            }
            if (booking.StartDate < DateTime.Now + new TimeSpan(0, 1, 0))
            {
                ModelState.AddModelError(nameof(Booking.StartDate), "Start date can't be in the past");
            }
            if (booking.StartDate + new TimeSpan(0, 29, 0) > booking.EndDate)
            {
                ModelState.AddModelError(nameof(Booking.EndDate), "Minimal recharging time is 30 minutes");
            }
            if (booking.StartDate.Date != booking.EndDate.Date)
            {
                ModelState.AddModelError(nameof(Booking.EndDate), "The resevation must end in the same day");
            }

            //https://fleetlogging.com/european-license-number-plates/
            //Some of the EU car plate number formats
            string strRegex = @"([A-Z]{2}\d{2}[A-Z]{3})|([B]{1}\d{2}[A-Z]{3})|([A-Z]{2}\d{3}[A-Z]{2})
                                    |([A-Z]{2}\d{5})|([A-Z]{3}\d{3})";
            Regex re = new Regex(strRegex);
            if (!re.IsMatch(booking.CarNumber))
            {
                ModelState.AddModelError(nameof(Booking.CarNumber), "Car plate number wrong format or non EU");
            }


            List<Booking> booketDayPeriod = _Context.Bookings.Where(m => m.StartDate.Year == booking.StartDate.Year &&
                                                                    m.StartDate.Month == booking.StartDate.Month &&
                                                                    m.StartDate.Day == booking.StartDate.Day).ToList();

            if (!(booketDayPeriod.Count == 0))
            {
                foreach (Booking b in booketDayPeriod)
                {
                    if (booking.StartDate < b.StartDate && booking.EndDate > b.StartDate)
                    {
                        ModelState.AddModelError(nameof(Booking.EndDate), "Other booking is schegule to start before this time, chose a end time befor this one");
                        break;
                    }
                    if (booking.StartDate > b.StartDate && booking.StartDate < b.EndDate)
                    {
                        ModelState.AddModelError(nameof(Booking.StartDate), "Other booking is schegule in this period, chose a start time after this one");
                        break;
                    }
                }
            }

            if (ModelState.IsValid)
            {
                Booking newBookingSave = new Booking();
                newBookingSave.StartDate = booking.StartDate;
                newBookingSave.EndDate = booking.EndDate;
                newBookingSave.CarNumber = booking.CarNumber;
                newBookingSave.PlugId = booking.PlugId;
                newBookingSave.Plug = _Context.Plugs.First(x => x.Id == booking.PlugId);
                _Context.Add(newBookingSave);
                _Context.SaveChanges();
                return RedirectToAction("Details", "RechargingStation", new { id = _Context.Plugs.First(m => m.Id == booking.PlugId).StationId });
            }
            else
            {
                return View("Index", booking);
            }

        }
    }
}
