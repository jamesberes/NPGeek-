using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyResultsViewModel
    {
        public Dictionary<string, int> Results { get; set; }
        public IList<Park> Parks { get; set; }
    }
}
