using Axis.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Axis.Repositories.Repositories
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly string _connectionString;
        public UtilityRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public void LogActivity(string Activity, int? UserId = null, string ActivityType = "General")
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            connection.Execute("usp_ActivityLog",
                new
                {
                    Activity = Activity,
                    UserId = UserId,
                    ActivityType = ActivityType
                },
                commandType: CommandType.StoredProcedure);
            connection.Close();
        }
    }
}
