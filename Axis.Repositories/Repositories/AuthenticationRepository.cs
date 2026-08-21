using Axis.Models;
using Axis.Repositories.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Axis.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly string _connectionString;

        public AuthenticationRepository(IConfiguration configuration)
        {
            this._connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        #region Login Repository
        public (UserSession user, string returnMsg) Login(string username)
             
        {
            using var connection = new SqlConnection(_connectionString);

            connection.Open();

            var parameters = new DynamicParameters();

            parameters.Add("@Username", username);
            parameters.Add("@returnMsg", dbType: DbType.String, direction: ParameterDirection.Output, size:50);
        
            // authentication through Login SP
            UserSession user = connection.QueryFirstOrDefault<UserSession>(
                "usp_Login",
                parameters,
                commandType: CommandType.StoredProcedure
                )!;
            string returnmsg = parameters.Get<string>("@returnMsg");
            connection.Close();
            return (user, returnmsg);
        }
        #endregion
    }
}
