using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryProductsFlaggingSystem.Infrastructure.Converters
{
    public interface IProductsConverter
    {
        public List<T> ConvertProducts<T>(List<string> products);
    }
}
