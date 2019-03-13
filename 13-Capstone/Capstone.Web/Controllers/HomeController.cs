using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

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

        public IActionResult Detail(string parkCode)
        {
            Park park = parkDal.GetPark(parkCode);
            IList<Weather> weather = weatherDal.GetWeatherByPark(parkCode);

            //send in a temperature scale?

            DetailViewModel dvm = new DetailViewModel(park, weather);

            return View(dvm);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var parks = parkDal.GetAllParks();

            return View(parks);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
