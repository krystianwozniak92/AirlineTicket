using System.Collections.Generic;
using System.Web.Mvc;
using Service;
using Model.QPX.Request;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About content.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public void Search()
        {
            FlightsService flightsService = new FlightsService();
            
            Request req = new Request();
            List<Slice> slices = new List<Slice>();
            Slice slice1 = new Slice();
            Slice slice2 = new Slice();

            slice1.Date = "2015-11-01";
            slice1.Destination = "ALC";
            slice1.Origin = "WRO";

            slice2.Date = "2015-11-01";
            slice2.Destination = "WRO";
            slice2.Origin = "ALC";

            slices.Add(slice1);
            slices.Add(slice2);
            req.Slice = slices;

            req.Passengers.AdultCount = 2;
            req.Passengers.ChildCount = 1;
            req.Solutions = 10;

            flightsService.SendRequest(req);
        }
    }
}