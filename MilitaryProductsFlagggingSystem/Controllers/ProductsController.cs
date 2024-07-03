using Microsoft.AspNetCore.Mvc;
using MilitaryProductsFlaggingSystem.Application.Interfaces;
using MilitaryProductsFlaggingSystem.Application.Services;
using MilitaryProductsFlaggingSystem.Domain.Common;

namespace MilitaryProductsFlagggingSystemMVC.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ISupplierServiceFactory _supplierServiceFactory;

        public ProductsController(ISupplierServiceFactory supplierServiceFactory)
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
            var supplierService = _supplierServiceFactory.CreateSupplierService(supplier);
            var products = supplierService.GetProducts(true);
            return View(products);
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
    }
}
