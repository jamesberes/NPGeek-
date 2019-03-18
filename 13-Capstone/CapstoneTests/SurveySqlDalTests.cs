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
    public class SurveySqlDalTests
    {
        private TransactionScope tran;
        private string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";
        private int surveyCount = 0;
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
                
                // Get the number of surveys
                cmd = new SqlCommand("SELECT count(*) FROM survey_result", connection); // WHERE parkCode = 'YNP2'
                surveyCount = (int)cmd.ExecuteScalar();

                // get number of parks (# of keys in dictionary for GetFavParkBySurveyCount)
                cmd = new SqlCommand("select count(*) from park;", connection);
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
        public void GetFavoriteParkBySurveyCountTest() //Dictionary<string, int> GetFavoriteParkBySurveyCount()
        {
            //Arange
            ISurveyDAL surveySqlDAL = new SurveySqlDAL(connectionString);

            //ACT
            Dictionary<string, int> surveys = surveySqlDAL.GetFavoriteParkBySurveyCount();

            //Assert
            Assert.IsNotNull(surveys, "Favorite surveys list is empty!");
            Assert.AreEqual(parkCount, surveys.Count, $"Expected a count of {surveyCount} for parks");
        }

        [TestMethod]
        public void SaveNewSurveyTest() //void SaveNewSurvey(Survey survey)
        {
            //Arange
            ISurveyDAL surveySqlDAL = new SurveySqlDAL(connectionString);
            Dictionary<string, int> surveys = surveySqlDAL.GetFavoriteParkBySurveyCount();
            Survey survey = new Survey()
            {
                ParkCode = "YNP2",
                Email = "test@email.com",
                State = "Ohio",
                ActivityLevel = "Inactive"
            };
            int before = surveys["YNP2"];

            //ACT
            surveySqlDAL.SaveNewSurvey(survey);

            //check that the added survey increased the # of votes for yosemite by 1. 
            Dictionary<string, int> surveysNew = surveySqlDAL.GetFavoriteParkBySurveyCount();
            int after = surveysNew["YNP2"];

            //Assert
            Assert.IsNotNull(surveysNew, "Yosemite should have at least 1 vote(survey).");
            Assert.AreEqual((before+1), after, $"Yosemite should have had {before} surveys before the add and {after} surveys after the add");
        }
    }
}