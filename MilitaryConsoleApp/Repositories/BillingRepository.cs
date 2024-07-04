using Dapper;
using Microsoft.Extensions.Options;
using MilitaryConsoleApp.Common;
using MilitaryConsoleApp.Configuration;
using MilitaryConsoleApp.Models;
using Serilog;
using System.Data.SqlClient;
using System.Transactions;

namespace MilitaryConsoleApp.Repositories
{
    public class BillingRepository : IBillingRepository
    {
        private readonly DatabaseConfig _databaseConfig;

        public BillingRepository(IOptions<DatabaseConfig> databaseConfig)
        {
            _databaseConfig = databaseConfig.Value;
        }

        public async Task SaveBillingEntryAsync(BillingEntry billingEntry)
        {
            using (SqlConnection connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                connection.Open();
                var transaction = connection.BeginTransaction("SaveBillingEntry");
                try
                {
                    var query = @"INSERT INTO BillingTable (billingId, occuredAt, orderId, offerId, typeId, typeName)
                                VALUES (@BillingId, @OccuredAt, @OrderId, @OfferId, @TypeId, @TypeName)";
                    await connection.ExecuteAsync(query, new
                    {
                        billingEntry.BillingId,
                        billingEntry.OccuredAt,
                        billingEntry.OrderId,
                        billingEntry.OfferId,
                        billingEntry.TypeId,
                        billingEntry.TypeName
                    }, transaction);

                    var taxQuery = @"INSERT INTO BillingTaxTable (billingId, percentage, annotation)
                                VALUES (@BillingId, @Percentage, @Annotation)";
                    await connection.ExecuteAsync(taxQuery, new
                    {
                        billingEntry.BillingId,
                        Percentage = billingEntry.TaxPercentage,
                        Annotation = billingEntry.TaxAnnotation
                    }, transaction);

                    var balanceQuery = @"INSERT INTO BillingBalanceTable (billingId, amount, currency)
                                VALUES (@BillingId, @Amount, @Currency)";
                    await connection.ExecuteAsync(balanceQuery, new
                    {
                        billingEntry.BillingId,
                        Amount = billingEntry.BalanceAmount,
                        Currency = billingEntry.BalanceCurrency
                    }, transaction);

                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    Log.Error("Error occured while saving data to database");
                    transaction.Rollback();
                }
            }
        }

        public async Task<IEnumerable<BillingEntry>> GetBillingsAsync(string id, GetBillingType type)
        {
            using (SqlConnection connection = new SqlConnection(_databaseConfig.ConnectionString))
            {
                var idType = type == GetBillingType.ByOrderId ? "orderId" : "offerId";
                var query = $"SELECT * FROM BillingTable where {idType} = '{id.Trim()}'";
                return await connection.QueryAsync<BillingEntry>(query);
            }
        }
    }
}
