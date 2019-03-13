using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAL : IWeatherDAL
    {
        private readonly string connectionString;
        private const string SQL_GetWeatherByPark = @"SELECT * FROM weather WHERE parkCode = @parkCode;";

        public WeatherSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Weather> GetWeatherByPark(string parkCode)
        {

            IList<Weather> weather = new List<Weather>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetWeatherByPark, conn);

                    cmd.Parameters.AddWithValue("parkCode", parkCode);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Weather singleWeather = new Weather()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                            Low = Convert.ToInt32(reader["low"]),
                            High = Convert.ToInt32(reader["high"]),
                            Forecast = Convert.ToString(reader["forecast"])
                        };

                        weather.Add(singleWeather);
                        
                    }
                }
            }
            catch
            {
                weather = new List<Weather>();
            }

            return weather;
        }
    }
}
