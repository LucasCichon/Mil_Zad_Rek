using MilitarySuplierFilesConsoleApp.Common;
using MilitarySuplierFilesConsoleApp.ErrorHandling;
using MilitarySuplierFilesConsoleApp.Models;
using MilitarySuplierFilesConsoleApp.Services;
using Serilog;

namespace MilitarySuplierFilesConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/log.txt",
                              rollingInterval: RollingInterval.Day,
                              retainedFileCountLimit: 7,
                              fileSizeLimitBytes: 10485760,
                              rollOnFileSizeLimit: true)
                .CreateLogger();

            Log.Information("Application Starting Up");


            IErrorHandler errorHandler = new ErrorHandler();
            errorHandler.Handle(() =>
            {
                ISupplierService suplier1Service = SupplierServiceFactory.GetService(SupplierType.supplier1);
                var productsFromSupplier1 = suplier1Service.GetFinalProducts(Directory.GetCurrentDirectory() + "\\dostawca1plik1.xml", Directory.GetCurrentDirectory() + "\\dostawca1plik2.xml");

                ISupplierService suplier2Sevice = SupplierServiceFactory.GetService(SupplierType.supplier2);
                var productsFromSupplier2 = suplier2Sevice.GetFinalProducts(Directory.GetCurrentDirectory() + "\\dostawca2plik1.xml", Directory.GetCurrentDirectory() + "\\dostawca2plik2.xml");

                ISupplierService suplier3Sevice = SupplierServiceFactory.GetService(SupplierType.supplier3);
                var productsFromSupplier3 = suplier3Sevice.GetFinalProducts(Directory.GetCurrentDirectory() + "\\dostawca3plik1.xml", null);


                var allProducts = new List<FinalProduct>();
                allProducts.AddRange(productsFromSupplier1);
                allProducts.AddRange(productsFromSupplier2);
                allProducts.AddRange(productsFromSupplier3);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(allProducts);
                Log.Debug(json);
            });

            Log.Information("Application is Closing");
        }
    }
}
