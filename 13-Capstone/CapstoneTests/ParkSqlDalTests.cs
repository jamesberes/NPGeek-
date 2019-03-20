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
    public class ParkSqlDalTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";
        private int parkCount = 0;

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
                cmd = new SqlCommand("SELECT count(*) FROM park", connection); // WHERE parkCode = 'YNP2'
                parkCount = (int)cmd.ExecuteScalar();
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
            //Arrange
            IParkDAL parkSqlDAL = new ParkSqlDAL(connectionString);

            //ACT
            IList<Park> parks = parkSqlDAL.GetAllParks();

            //Assert
            Assert.IsNotNull(parks, "Parks list is empty!");
            Assert.AreEqual(parkCount, parks.Count, $"Expected a count of {parkCount} for parks");
        }

        [TestMethod]
        public void GetParkTest() //Park GetPark(string parkCode)
        {
            //Arrange
            IParkDAL parkSqlDAL = new ParkSqlDAL(connectionString);


            //ACT
            Park park = parkSqlDAL.GetPark("YNP2");

            //Assert
            Assert.IsNotNull(park, "Yosemite was not found");
            Assert.AreEqual("California", park.State, "Yosemite should be in California");
            Assert.AreEqual(1890, park.YearFounded, "Incorrect YearFounded associated with Yosemite. Should be 1890");
        }

        [TestMethod]
        public void GetParkSelectListTest() //List<SelectListItem> GetParkSelectList()
        {
            //Arrange
            IParkDAL parkSqlDAL = new ParkSqlDAL(connectionString);

            //ACT
            List<SelectListItem> parkSelectList = parkSqlDAL.GetParkSelectList();

            //Assert
            Assert.IsNotNull(parkSelectList, "parkSelectList is empty!");
            Assert.AreEqual(parkCount, parkSelectList.Count, $"Expected a count of {parkCount} for parkSelectList");
        }
    }
}