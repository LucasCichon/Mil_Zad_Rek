using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MilitarySuplierFilesConsoleApp.Models;

namespace MilitarySuplierFilesConsoleApp.Services
{
    public interface ISupplierService
    {
        List<FinalProduct> GetFinalProducts(string path1, string path2 = null);
    }
}
