using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }

        public int HighCelcius
        {
            get { return (int)(Math.Round((High - 32) / 1.8)); }
        }

        public int LowCelcius
        {
            get { return (int)(Math.Round((Low - 32) / 1.8)); }
        }
    }
}
