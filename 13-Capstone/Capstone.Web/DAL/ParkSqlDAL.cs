using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private string connectionString;
        private const string SQL_GetAllParks = "SELECT * FROM park";

        public ParkSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(SQL_GetAllParks, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Park park = new Park();

                        park.ParkCode = Convert.ToString(reader["parkCode"]);
                        park.ParkName = Convert.ToString(reader["parkName"]);
                        park.State = Convert.ToString(reader["state"]);
                        park.Acreage = Convert.ToInt32(reader["acreage"]);
                        park.ElevationInFt = Convert.ToInt32(reader["elevationInFeett"]);
                        park.MilesOfTrail = Convert.ToDouble(reader["milesOfTrail"]);
                        park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                        park.Climate = Convert.ToString(reader["climate"]);
                        park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                        park.AnnualVisitors = Convert.ToInt32(reader["annualVisitorCount"]);
                        park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                        park.QuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                        park.Description = Convert.ToString(reader["parkDescription"]);
                        park.EntryFee = Convert.ToDecimal(reader["entryFee"]);
                        park.NumberOfSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

                        parks.Add(park);
                    }
                }
            }

            catch (SqlException)
            {
                parks = new List<Park>();
            }

            return parks;
        }

        public Park GetPark(string parkCode)
        {
            return GetAllParks().FirstOrDefault(p => p.ParkCode == parkCode);
        }
    }
}
