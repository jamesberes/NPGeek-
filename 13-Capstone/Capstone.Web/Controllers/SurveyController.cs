using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDAL;
        private IParkDAL parkDAL;

        public SurveyController(ISurveyDAL surveyDAL, IParkDAL parkDAL)
        {
            this.surveyDAL = surveyDAL;
            this.parkDAL = parkDAL;
        }

        [HttpGet]
        public IActionResult NewSurvey()
        {
            //IList<Park> parks = parkDAL.GetAllParks();
            Survey survey = new Survey()
            {
                Parks = parkDAL.GetParkSelectList()
            };
            //ViewBag.ParkSelectList = parkDAL.GetParkSelectList();
            return View(survey);
        }
    }
}