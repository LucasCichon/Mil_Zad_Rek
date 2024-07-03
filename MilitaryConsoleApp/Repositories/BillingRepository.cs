using Dapper;
using Microsoft.Extensions.Options;
using MilitaryConsoleApp.Common;
using MilitaryConsoleApp.Configuration;
using MilitaryConsoleApp.Models;
using System.Data.SqlClient;

namespace MilitaryConsoleApp.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public BillingRepository(IOptions<DatabaseConfig> databaseConfig)
        {
            _databaseConfig = databaseConfig.Value;
        }

        public async Task<IEnumerable<BillingEntry>> GetBillingsAsync(string id, GetBillingType type)
        {
            using (SqlConnection connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                var idType = type == GetBillingType.ByOrderId ? "orderId" : "offerId";
                var query = $"SELECT * FROM BillingTable where {idType} = '{id}'";
                return await connection.QueryAsync<BillingEntry>(query);
            }
        }

        public async Task SaveBillingEntriesAsync(IEnumerable<BillingEntry> billingEntries)
        {
            using (SqlConnection connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                foreach (var entry in billingEntries)
                {
                    var query = @"INSERT INTO BilllingTable (billingId, occuredAt, orderId, offerId, typeId, typeName)
                              VALUES (@BillingId, @OccuredAt, @OrderId, @OfferId, @TypeId, @TypeName)";
                    await connection.ExecuteAsync(query, new
                    {
                        entry.BillingId,
                        entry.OccuredAt,
                        entry.OrderId,
                        entry.OfferId,
                        entry.TypeId,
                        entry.TypeName
                    });

                    var taxQuery = @"INSERT INTO BilllingTaxTable (billingId, percentage, annotation)
                              VALUES (@BillingId, @Percentage, @Annotation)";
                    await connection.ExecuteAsync(taxQuery, new
                    {
                        entry.BillingId,
                        Percentage = entry.TaxPercentage,
                        Annotation = entry.TaxAnnotation
                    });

                    var balanceQuery = @"INSERT INTO BilllingBalanceTable (billingId, amount, currency)
                              VALUES (@BillingId, @Amount, @Currency)";
                    await connection.ExecuteAsync(balanceQuery, new
                    {
                        entry.BillingId,
                        Amount = entry.BalanceAmount,
                        Currency = entry.BalanceCurrency
                    });
                }
            }
        }
    }
}
