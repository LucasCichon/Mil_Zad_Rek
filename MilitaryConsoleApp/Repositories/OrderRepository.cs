using Dapper;
using Microsoft.Extensions.Options;
using MilitaryConsoleApp.Configuration;
using System.Data.SqlClient;

namespace MilitaryConsoleApp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public OrderRepository(IOptions<DatabaseConfig> databaseConfig)
        {
            _databaseConfig = databaseConfig.Value;
        }

        public async Task<IEnumerable<Models.Order>> GetOrdersAsync()
        {
            using (SqlConnection connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                var query = "SELECT * FROM OrderTable";
                return await connection.QueryAsync<Models.Order>(query);
            }
        }
    }
}
