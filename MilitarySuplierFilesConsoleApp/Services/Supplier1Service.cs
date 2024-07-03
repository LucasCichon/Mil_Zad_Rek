using HtmlAgilityPack;
using MilitarySuplierFilesConsoleApp.Dtos.suplier1;
using MilitarySuplierFilesConsoleApp.Helpers;
using MilitarySuplierFilesConsoleApp.Models;

namespace MilitarySuplierFilesConsoleApp.Services
{
    public class Supplier1Service : ISupplierService
    {
        private readonly IFileWrapper _fileWrapper;

        public Supplier1Service(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        public Supplier1Service() : this(new FileWrapper())
        {
        }

        public List<FinalProduct> GetFinalProducts(string path1, string path2)
        {
            var result = new List<FinalProduct>();
            var file1_1 = _fileWrapper.ReadTextFromFile(path1);
            var file1_2 = _fileWrapper.ReadTextFromFile(path2);

            Offer offer1 = XmlHelper.DeserializeFromXml<Offer>(file1_1);
            Offer offer2 = XmlHelper.DeserializeFromXml<Offer>(file1_2);

            foreach (var product in offer1.Products.ProductList)
            {
                var fp = CreateFinalProduct(product, offer2.Products);
                if (fp != null)
                {
                    result.Add(fp);
                }
            }
            return result;
        }

        private static FinalProduct CreateFinalProduct(Product product, Products productsFromSecondFile)
        {
            var productFrom2File = productsFromSecondFile.ProductList.FirstOrDefault(p => p.Id == product.Id);

            var builder = new FinalProduct.Builder(product.Id.ToString());

            //Tutaj pozwoliłem sobie wyciągnąć jedynie polską nazwę
            builder.WithName(productFrom2File?.description.Names.FirstOrDefault(n => n.Lang == "pol")?.Value ?? string.Empty);
            //Tutaj mam pewne wątpliwości, ponieważ jest rozjazd w plikach. Postanowiłem zsumować wartości.
            builder.WithStockQuantity(product?.Sizes.SizeList.Select(s => s.Stock.Quantity).Sum() ?? 0 + productFrom2File?.Sizes.SizeList.Select(s => s.Stock.Quantity).Sum() ?? 0);
            builder.WithImgUrls(GetImages(productFrom2File));
            builder.WithDescriptions(GetDescriptions(productFrom2File));

            return builder.Build();
        }

        private static List<Models.Description> GetDescriptions(Product productFrom2File)
        {
            return productFrom2File?.description.LongDescs.Select(p =>
            {
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(p.Value);
                string current = htmlDoc.DocumentNode.InnerText;

                return new Models.Description()
                {
                    Lang = p.Lang,
                    Desc = current,
                };
            }).ToList() ?? new List<Models.Description>();
        }

        private static List<string> GetImages(Product productFrom2File) => productFrom2File?.Images.LargeImages.Images.Select(i => i.Url).ToList() ?? new List<string>();
    }
}
