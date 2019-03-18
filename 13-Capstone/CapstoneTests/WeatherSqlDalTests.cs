using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Transactions;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using System;
using Capstone;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CapstoneTests
{
    [TestClass]
    public class WeatherSqlDalTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";
        private int weatherCount = 0;

        //INITIALIZE
        [TestInitialize]
        public void Initialize()
        {
            tran = new TransactionScope();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd;

                // Get the number of parks
                cmd = new SqlCommand("SELECT count(*) FROM weather where parkCode = 'YNP2';", connection);
                weatherCount = (int)cmd.ExecuteScalar();
            }
        }

        /*
        * CLEANUP
        * Rollback the existing transaction.
        */
        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void GetAllParksTest() //IList<Park> GetAllParks()
        {
            //Arange
            IWeatherDAL weatherSqlDAL = new WeatherSqlDAL(connectionString);

            //ACT
            IList<Weather> yosemiteWeather = weatherSqlDAL.GetWeatherByPark("YNP2");

            //Assert
            Assert.IsNotNull(yosemiteWeather, "Parks list is empty!");
            Assert.AreEqual(weatherCount, yosemiteWeather.Count, $"Expected a count of {weatherCount} for yosemite's weather.");
        }
    }
}
