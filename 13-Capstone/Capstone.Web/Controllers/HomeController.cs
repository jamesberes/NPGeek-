using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private IParkDAL parkDal;
        private IWeatherDAL weatherDal;

        // create with DALs for convenience
        public HomeController(IParkDAL parkDal, IWeatherDAL weatherDal)
        {
            this.parkDal = parkDal;
            this.weatherDal = weatherDal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var parks = parkDal.GetAllParks();

            return View(parks);
        }

        public IActionResult Detail(string parkCode)
        {
            var park = parkDal.GetPark(parkCode);
            return View(park);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
