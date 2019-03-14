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
            //get tempScale (default or via SetTempScale)
            //I feel like I'm not actually using the session b/c I'm saving it as a value in the model. 
            string tempScale = HttpContext.Session.GetString("tempScale");

            //if not set yet
            if (tempScale == null)
            {
                tempScale = "F";
                HttpContext.Session.SetString("tempScale", tempScale); //this defaults the weather to Fahrenheit scale (could base on location?)
            }
            //if set to fahrenheit **FROM** celcius
            else if (tempScale == "tempF") 
            {
                tempScale = "F"; //set tempscale to F (for detail page weather report) if fahrenheit is chosen by button
            }
            //if set to celcius from fahrenheit
            else
            {
                tempScale = "C"; //set tempscale to C (for detail page weather report) if fahrenheit is chosen by button
            }

            DetailViewModel dvm = new DetailViewModel(park, weather);
            dvm.TempScale = tempScale; //load the detailViewModel with our tempscale. 
            return View(dvm);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var parks = parkDal.GetAllParks();

            return View(parks);
        }

        //action for our TempScale Buttons in the Detail View Model.
        [HttpPost]
        public IActionResult SetTempScale(string parkCode, string temperatureScale)
        {
            //saves the new choice into session string "tempScale"
            HttpContext.Session.SetString("tempScale", temperatureScale);

            //redirect to Detail page of home controller and pass the parkCode (needed)
            return RedirectToAction("Detail", "Home", new { parkCode }); //From Andrew's lecture
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
