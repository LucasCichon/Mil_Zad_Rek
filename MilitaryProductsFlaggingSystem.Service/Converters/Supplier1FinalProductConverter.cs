using MilitaryProductsFlaggingSystem.Application.Converters.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model;
using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryProductsFlaggingSystem.Application.Converters
{
    public class Supplier1FinalProductConverter : IFinalProductConverter<Offer>
    {
        public List<FinalProduct> Convert(List<Offer> list)
        {
            throw new NotImplementedException();
        }
    }
}
