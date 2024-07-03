using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitarySuplierFilesConsoleApp.Helpers
{
    public interface IFileWrapper
    { 
        public string ReadTextFromFile(string filePath);
    }
}
