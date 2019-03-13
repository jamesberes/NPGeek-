using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;

namespace Capstone.Web.DAL
{
    public class ParkSqlDAL : IParkDAL
    {
        private string connectionString;

        public ParkSqlDAL (string connectionString)
        {
            this.connectionString = connectionString;
        }


    }
}
