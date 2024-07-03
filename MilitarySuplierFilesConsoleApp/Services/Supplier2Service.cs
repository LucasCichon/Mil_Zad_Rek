using MilitarySuplierFilesConsoleApp.Dtos.suplier2;
using MilitarySuplierFilesConsoleApp.Helpers;
using MilitarySuplierFilesConsoleApp.Models;
using System.Xml.Serialization;

namespace MilitarySuplierFilesConsoleApp.Services
{
    public class Supplier2Service : ISupplierService
    {
        private readonly IFileWrapper _fileWrapper;

        public Supplier2Service(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        public Supplier2Service() : this(new FileWrapper())
        {
        }

        public List<FinalProduct> GetFinalProducts(string path1, string path2)
        {
            var result = new List<FinalProduct>();

            var file2_1 = _fileWrapper.ReadTextFromFile(path1);
            var file2_2 = _fileWrapper.ReadTextFromFile(path2);

            Products products1 = XmlHelper.DeserializeFromXml<Products>(file2_1);
            Products products2 = XmlHelper.DeserializeFromXml<Products>(file2_2);


            foreach (var product in products1.ProductList)
            {
                var fp = CreateFinalProduct(product, products2);
                if(fp != null)
                {
                    result.Add(fp);
                }
            }

            return result;
        }

        private static FinalProduct CreateFinalProduct(Product product, Products productsFromScondFile)
        {
            var product2 = productsFromScondFile.ProductList.FirstOrDefault(p => p.Id == product.Id);

            var builder = new FinalProduct.Builder(product.Id.ToString());
            builder.WithName(product2?.Name ?? string.Empty);
            builder.WithDescriptions(new List<Description>() { new Description() { Lang = "pol", Desc = product2?.Description ?? string.Empty } });
            builder.WithImgUrls(product2?.Photos?.Select(p => p.URL).ToList() ?? new List<string>());
            builder.WithStockQuantity(product.Quantity);

            return builder.Build();
        }
    }
}