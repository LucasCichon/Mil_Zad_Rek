using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryConsoleApp.Services
{
    public interface IOfferService
    {
        Task<IEnumerable<Models.Offer>> GetOffersAsync();
    }
}
