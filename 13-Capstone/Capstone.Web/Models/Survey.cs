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
        [Display(Name = "Activity Level:")]
        public string ActivityLevel { get; set; }

        public List<SelectListItem> Parks { get; set; }

        public static List<SelectListItem> ActivityLevels = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Inactive" },
            new SelectListItem() { Text = "Sedentary" },
            new SelectListItem() { Text = "Active" },
            new SelectListItem() { Text = "Extremely Active" }
        };

        public static List<SelectListItem> States = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Alabama" },
            new SelectListItem { Text = "Alaska" },
            new SelectListItem { Text = "Arizona" },
            new SelectListItem { Text = "Arkansas" },
            new SelectListItem { Text = "California" },
            new SelectListItem { Text = "Colorado" },
            new SelectListItem { Text = "Connecticut" },
            new SelectListItem { Text = "Delaware" },
            new SelectListItem { Text = "Florida" },
            new SelectListItem { Text = "Georgia" },
            new SelectListItem { Text = "Hawaii" },
            new SelectListItem { Text = "Idaho" },
            new SelectListItem { Text = "Illinois" },
            new SelectListItem { Text = "Indiana" },
            new SelectListItem { Text = "Iowa" },
            new SelectListItem { Text = "Kansas" },
            new SelectListItem { Text = "Kentucky" },
            new SelectListItem { Text = "Louisiana" },
            new SelectListItem { Text = "Maine" },
            new SelectListItem { Text = "Maryland" },
            new SelectListItem { Text = "Massachusetts" },
            new SelectListItem { Text = "Michigan" },
            new SelectListItem { Text = "Minnesota" },
            new SelectListItem { Text = "Mississippi" },
            new SelectListItem { Text = "Missouri" },
            new SelectListItem { Text = "Montana" },
            new SelectListItem { Text = "North Carolina" },
            new SelectListItem { Text = "North Dakota" },
            new SelectListItem { Text = "Nebraska" },
            new SelectListItem { Text = "Nevada" },
            new SelectListItem { Text = "New Hampshire" },
            new SelectListItem { Text = "New Jersey" },
            new SelectListItem { Text = "New Mexico" },
            new SelectListItem { Text = "New York" },
            new SelectListItem { Text = "Ohio" },
            new SelectListItem { Text = "Oklahoma" },
            new SelectListItem { Text = "Oregon" },
            new SelectListItem { Text = "Pennsylvania" },
            new SelectListItem { Text = "Rhode Island" },
            new SelectListItem { Text = "South Carolina" },
            new SelectListItem { Text = "South Dakota" },
            new SelectListItem { Text = "Tennessee" },
            new SelectListItem { Text = "Texas" },
            new SelectListItem { Text = "Utah" },
            new SelectListItem { Text = "Vermont" },
            new SelectListItem { Text = "Virginia" },
            new SelectListItem { Text = "Washington" },
            new SelectListItem { Text = "West Virginia" },
            new SelectListItem { Text = "Wisconsin" },
            new SelectListItem { Text = "Wyoming" }
        };

    }
}
