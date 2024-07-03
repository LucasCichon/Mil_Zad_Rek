using Microsoft.Extensions.Options;
using MilitaryConsoleApp.Common;
using MilitaryConsoleApp.Configuration;
using MilitaryConsoleApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryConsoleApp.Clients
{
    public class AllegroClient : IAllegroClient
    {
        private readonly ApiConfig _apiConfig;

        public AllegroClient(IOptions<ApiConfig> apiConfig)
        {
            _apiConfig = apiConfig.Value;
        }
        public async Task<List<BillingEntry>> GetBillingEntries(string id, GetBillingType type)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiConfig.Token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.allegro.public.v1+json"));

                HttpResponseMessage response = await client.GetAsync($"{_apiConfig.ApiUrl}/billing/billing-entries{GetParams(id, type)}");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                var dtos = JsonConvert.DeserializeObject<BillingEntries>(responseBody);

                var entries = new List<BillingEntry>();
                foreach (var entry in dtos.Items)
                {
                    entries.Add(CreateBillingEntry(entry));
                }

                return entries;
            }
        }

        private string GetParams(string id, GetBillingType type)
        {
            return !string.IsNullOrEmpty(id) ? $"?{GetIdTypeParam(type)}={id}" : string.Empty;
        }

        private string GetIdTypeParam(GetBillingType type)
        {
            return type switch
            {
                GetBillingType.ByOrderId => "order.id",
                GetBillingType.ByOfferId => "offer.id",
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private BillingEntry CreateBillingEntry(BillingEntryDto entry)
        {
            var builder = new BillingEntry.Builder();
            if(entry == null)
            {
                return builder.Build();
            }

            builder.WithBillingId(entry.Id.ToString());
            builder.WithOfferId(entry.Offer?.Id ?? string.Empty);
            builder.WithOrderId(entry.Order?.Id.ToString() ?? string.Empty);
            builder.WithTypeId(entry.Type?.Id ?? string.Empty);
            builder.WithTypeName(entry.Type?.Name ?? string.Empty);
            builder.WithBalanceAmount(decimal.Parse(entry.Value.Amount.Replace(".", Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator)));
            builder.WithBalanceCurrency(entry.Value?.Currency ?? string.Empty);
            builder.WithOccuredAt(entry.OccurredAt);
            builder.WithTaxAnnotation(entry.Tax?.Annotation ?? string.Empty);
            builder.WithTaxPercentage(entry.Tax?.Percentage ?? string.Empty);

            return builder.Build();
        }
    }
}
