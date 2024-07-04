using MilitarySuplierFilesConsoleApp.Dtos.suplier3;
using MilitarySuplierFilesConsoleApp.Helpers;
using MilitarySuplierFilesConsoleApp.Models;

namespace MilitarySuplierFilesConsoleApp.Services
{
    public class Supplier3Service : ISupplierService
    {
        private readonly IFileWrapper _fileWrapper;

        public Supplier3Service(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        public Supplier3Service() : this(new FileWrapper())
        {
        }
        public List<FinalProduct> GetFinalProducts(string path1, string path2)
        {
            var result = new List<FinalProduct>();
            var file3_1 = _fileWrapper.ReadTextFromFile(path1);

            Produkty produkty = XmlHelper.DeserializeFromXml<Produkty>(file3_1);
            foreach (var produkt in produkty.ProduktyList)
            {
                result.Add(CreateFinalProduct(produkt));
            }

            return result;
        }

        private static FinalProduct CreateFinalProduct(Produkt produkt)
        {
            var builder = new FinalProduct.Builder(produkt.Id);
            builder.WithName(produkt.Nazwa);
            builder.WithDescriptions(new List<Description>()
                    {
                        new Description() { Lang = "pol", Desc = produkt.DlugiOpisPl },
                        new Description() { Lang = "eng", Desc = produkt.DlugiOpisEn }
                    });
            builder.WithImgUrls(produkt.Zdjecia.Select(z => z.Url).ToList());

            return builder.Build();
        }
    }
}
