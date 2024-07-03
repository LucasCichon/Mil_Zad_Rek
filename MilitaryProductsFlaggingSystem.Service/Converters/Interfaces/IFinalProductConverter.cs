using MilitaryProductsFlaggingSystem.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryProductsFlaggingSystem.Application.Converters.Interfaces
{
    public interface IFinalProductConverter<T>
    {
        List<FinalProduct> Convert(List<T> list);
    }
}
