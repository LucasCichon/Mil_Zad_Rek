using MilitaryConsoleApp.Common;
using MilitaryConsoleApp.Models;

namespace MilitaryConsoleApp.Repositories
{
    public interface IBillingRepository
    {
        Task<IEnumerable<BillingEntry>> GetBillingsAsync(string id, GetBillingType type);
        Task SaveBillingEntryAsync(BillingEntry billingEntry);
    }
}
