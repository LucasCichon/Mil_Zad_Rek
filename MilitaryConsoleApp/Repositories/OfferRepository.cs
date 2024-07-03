using Dapper;
using Microsoft.Extensions.Options;
using MilitaryConsoleApp.Configuration;
using System.Data.SqlClient;

namespace MilitaryConsoleApp.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public OfferRepository(IOptions<DatabaseConfig> databaseConfig)
        {
            _databaseConfig = databaseConfig.Value;
        }

        public async Task<IEnumerable<Models.Offer>> GetOffersAsync()
        {
            using (SqlConnection connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                var query = "SELECT * FROM OfferTable";
                return await connection.QueryAsync<Models.Offer>(query);
            }
        }
    }
}
