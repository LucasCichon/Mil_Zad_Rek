using MilitaryProductsFlaggingSystem.Application.Converters.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model;
using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryProductsFlaggingSystem.Application.Converters
{
    public class Supplier2FinalProductConverter : IFinalProductConverter<Product>
    {
        public List<FinalProduct> Convert(List<Product> list)
        {
            throw new NotImplementedException();
        }
    }
}
