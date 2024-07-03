using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryConsoleApp.Services
{
    public interface IBillingService
    {
        public Task ProcessOrdersBillingEntriesAsync();
        public Task ProcessOffersBillingEntriesAsync();
    }
}
