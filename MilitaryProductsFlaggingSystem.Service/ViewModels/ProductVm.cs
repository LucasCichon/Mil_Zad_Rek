using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryProductsFlaggingSystem.Application.ViewModels
{
    public class ProductVm
    {
        public string Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Opis")]
        public List<Description> Descriptions { get; set; } = new List<Description>();
        [DisplayName("Zdjęcie")]
        public List<string> ImgUrls { get; set; }
        [DisplayName("Stan")]
        public int stockQuantity { get; set; }
        [DisplayName("Flaga")]
        public bool isFlagged { get; set; }
    }
    public class Description
    {
        public string Lang { get; set; }
        public string Desc { get; set; }
    }
}
