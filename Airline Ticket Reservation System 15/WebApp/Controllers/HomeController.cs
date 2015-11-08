using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Service;
using Model.QPX.Request;
using Model.ViewModels;
using Service.Interfaces;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IFlightsService _flightsService;

        public HomeController(IFlightsService flightsService)
        {
            _flightsService = flightsService;
        }
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

        public async Task<ActionResult> Search(SearchFlightRequest request)
        {
            request.PassengerCount = new int[5];
            request.PassengerCount[0] = 2;
            request.PassengerCount[1] = 0;
            request.PassengerCount[2] = 0;
            request.PassengerCount[3] = 0;
            request.PassengerCount[4] = 0;
            request.IsRoundTrip = true;
            var result = await _flightsService.GetFlights(request);
            var model = new TestModel {Content = result};
            return View(model);
        }

        //public ActionResult Search(string departure)
        //{
        //    return View();
        //}
    }
}