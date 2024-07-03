using MilitaryConsoleApp.Common;
using MilitaryConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryConsoleApp.Clients
{
    public interface IAllegroClient
    {
        Task<List<BillingEntry>> GetBillingEntries(string id, GetBillingType type);
    }
}
