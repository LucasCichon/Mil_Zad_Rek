using MilitaryProductsFlaggingSystem.Application.Converters.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model;
using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryProductsFlaggingSystem.Application.Converters
{
    public class Supplier3FinalProducConverter : IFinalProductConverter<Produkt>
    {
        public List<FinalProduct> Convert(List<Produkt> list)
        {
            throw new NotImplementedException();
        }
    }
}
