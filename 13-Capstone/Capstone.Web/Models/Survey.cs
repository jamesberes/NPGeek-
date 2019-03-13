using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace Capstone.Web.Models
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string ParkName { get; set; }

        [Display(Name = "Select your favorite park:")]
        public string ParkCode { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "State of Residence")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Activity Level")]
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
