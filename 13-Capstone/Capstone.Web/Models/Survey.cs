using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string ParkName { get; set; }
        public string ParkCode { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string ActivityLevel { get; set; }

        public List<SelectListItem> Parks { get; set; }

        public static List<SelectListItem> ActivityLevels = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Inactive" },
            new SelectListItem() { Text = "Sedentary" },
            new SelectListItem() { Text = "Active" },
            new SelectListItem() { Text = "Extremely Active" }
        };
    }
}
