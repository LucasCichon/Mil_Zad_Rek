using MilitaryConsoleApp.Common;
using MilitaryConsoleApp.Models;

namespace MilitaryConsoleApp.Repositories
{
    public interface IBillingRepository
    {
        Task SaveBillingEntriesAsync(IEnumerable<BillingEntry> billingEntries);
        Task<IEnumerable<BillingEntry>> GetBillingsAsync(string id, GetBillingType type);
    }
}
