using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class DetailViewModel
    {
        public Park Park { get; set; }
        public IList<Weather> Weather { get; set; }
        public string TempScale { get; set; }

        public DetailViewModel(Park park, IList<Weather> weather)
        {
            Park = park;
            Weather = weather;
        }

        private Dictionary<string, string> WeatherRecommendations = new Dictionary<string, string>()
        {
            { "snow", "Pack your snowshoes! " },
            { "rain", "Pack your rain gear and waterproof shoes! " },
            { "thunderstorms", "Seek shelter and avoid hiking on exposed ridges. " },
            { "sunny", "Don't forget the sunblock! " },
            { "cloudy", " " },
            { "partlyCloudy", " " }
        };

        public string TempRecommendations(Weather weather)
        {
            string tempRecommend = "";
            if (weather.High > 75)
            {
                tempRecommend = "Bring an extra gallon of water!";
            }
            else if (weather.High - weather.Low > 20)
            {
                tempRecommend = "Wear breathable layers!";
            }
            else if (weather.Low < 20)
            {
                tempRecommend = "Danger! Frigid temperatures!";
            }
            else
            {
                tempRecommend = "";
            }

            return WeatherRecommendations[weather.Forecast] + tempRecommend;
        }
    }
}
