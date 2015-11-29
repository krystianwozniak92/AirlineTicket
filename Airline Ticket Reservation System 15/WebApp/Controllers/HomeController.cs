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
            var model = new SearchFlightRequest();
            return View(model);
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

        [HttpPost]
        public async Task<ActionResult> Search(SearchFlightRequest request)
        {
            var model = await _flightsService.GetFlights(request);
            return View(model);
        }
    }
}