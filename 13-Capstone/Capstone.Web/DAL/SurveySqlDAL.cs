using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private readonly string connectionString;
        private const string SQL_GetFavoriteParkBySurveyCount = "SELECT COUNT(*) AS surveyCount, parkCode FROM survey_result GROUP BY parkCode ORDER BY surveyCount DESC, parkCode;";
        string SQL_SaveNewSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Dictionary<string, int> GetFavoriteParkBySurveyCount()
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_GetFavoriteParkBySurveyCount, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string parkCode = Convert.ToString(reader["parkCode"]);
                        int surveyCount = Convert.ToInt32(reader["surveyCount"]);

                        output.Add(parkCode, surveyCount);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;

        }

        public void SaveNewSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(SQL_SaveNewSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.Email);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
