using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitarySuplierFilesConsoleApp.Helpers
{
    public class FileWrapper : IFileWrapper
    {
        public string ReadTextFromFile(string filePath) => File.ReadAllText(filePath);
    }
}
