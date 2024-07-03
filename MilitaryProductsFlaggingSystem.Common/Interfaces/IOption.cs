using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryProductsFlaggingSystem.Common.Interfaces
{
    public interface IOption<T>
    {
        TResult Match<TResult>(Func<T, TResult> some, Func<TResult> none);

    }
}
