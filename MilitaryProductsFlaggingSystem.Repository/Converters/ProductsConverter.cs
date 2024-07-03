using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryProductsFlaggingSystem.Infrastructure.Converters
{
    public class ProductsConverter : IProductsConverter
    {
        public List<T> ConvertProducts<T>(List<string> products)
        {
            throw new NotImplementedException();
        }
    }
}
