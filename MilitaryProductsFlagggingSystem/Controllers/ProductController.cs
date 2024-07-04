using Microsoft.AspNetCore.Mvc;
using MilitaryProductsFlaggingSystem.Application.Services;
using MilitaryProductsFlaggingSystem.Application.ViewModels;
using MilitaryProductsFlaggingSystem.Domain.Common;

namespace MilitaryProductsFlagggingSystemMVC.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISupplierServiceFactory _supplierServiceFactory;

        public ProductController(ISupplierServiceFactory supplierServiceFactory)
        {
            _supplierServiceFactory = supplierServiceFactory;
        }
        //Chose the Supplier and request for products
        public IActionResult Index()
        {
            return View();
        }

        //GetSupplierProducts
        public IActionResult Products(Supplier supplier)
        {
            //var supplierService = _supplierServiceFactory.CreateSupplierService(supplier);
            //var finalProducts = supplierService.GetProducts(true);
            
            List<ProductVm> testData = GetTestData();

            return View(testData);
        }

        public IActionResult FlaggProducts(Supplier supplier, Dictionary<string, bool> id_isFlagged)
        {
            var supplierService = _supplierServiceFactory.CreateSupplierService(supplier);
            var result = supplierService.FlaggProducts(id_isFlagged);

            return result.Match((Error) =>
            {
                return RedirectToAction("Error", Error);
            },
            () =>
            {
                return RedirectToAction("Index");
            });
        }

        private static List<ProductVm> GetTestData()
        {
            return new List<ProductVm>() {
                    new ProductVm() { Id = "1", Name = "Termos Fjord", Descriptions = new List<Description>() { new Description() { Desc = "Termos <strong>Fjord Nansen</strong> <strong>HONER</strong> to niekwestionowany lider w swojej klasie. Doskonały termos turystyczny wyposażony w niezawodny, wkręcany korek, gwarantujący najwyższe parametry termiczne. Posiada doskonałą izolację termiczną zarówno dla płynów gorących jak i zimnych przy dużej odporności na uszkodzenia mechaniczne. Dodatkowo zastosowanie gumowanej czarnej okładziny zapewnia pewny chwyt i świetnie wygląda.</p>\r\n<p>W termosie <strong>HONER</strong> zastosowano klasyczny wkręcany korek. Do napełnienia kubka wystarczy lekko go odkręcić i przechylić - chroni to jego zawartość przed niepotrzebnym wychłodzeniem.</p>\r\n<p>Termosy z serii <strong>HONER</strong> zwyciężają w testach turystycznych. Testy polegały na zalaniu wrzątkiem termosów i sprawdzeniu co 2 godziny temperatury.", Lang = "pol" } }, ImgUrls = new List<string> { "https://b2b.fjordnansen.pl/hpeciai/b26c9b6abfe3bf27d309875acabcbfc9/9944.webp" }, isFlagged = false, stockQuantity = 33 },
                    new ProductVm() { Id = "2", Name = "Softshell Falcon grey M", Descriptions = new List<Description>() { new Description() { Desc = "elastyczny materiał zwiększający komfort ruchu,\r\n-zespolona polarowa podpinka zapewniająca doskonałą ciepłotę ciała,\r\n-dwie duże zasuwane  kieszenie piersiowe,\r\n-trzy zasuwane kieszenie na rękawach, dwie wyposażone dodatkowo w panele velcro,\r\n-tylna duża kieszeń zamykana na zamki błyskawiczne,\r\n-regulacja kaptura, mankietów i dolnej części kurtki,", Lang = "pol" } }, ImgUrls = new List<string> { "https://texar.info.pl/img/towary/1/2019_03/softshell-falcon-grey.jpg" }, isFlagged = true, stockQuantity = 12 } ,
                    new ProductVm() { Id = "3", Name = "Pędzelek Lens Pen", Descriptions = new List<Description>() { new Description() { Desc = "Flamaster do czyszczenia soczewek \"Magic Lens Pen\" jest nowym, wysoko użytecznym przyrządem pozwalającym na proste usuwanie odcisków palców, tłustych plam i innych zanieczyszczeń z powierzchni optyki teleskopu", Lang = "pol" } }, ImgUrls = new List<string> { "https://b2b.deltaoptical.pl/zasoby/import/l/lens-pen_4_1_2.jpg" }, isFlagged = false, stockQuantity = 15 }
                };
        }
    }
}
