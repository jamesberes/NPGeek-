using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private string connectionString;

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
