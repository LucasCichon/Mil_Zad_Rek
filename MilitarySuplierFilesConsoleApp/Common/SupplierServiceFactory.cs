using MilitarySuplierFilesConsoleApp.Services;

namespace MilitarySuplierFilesConsoleApp.Common
{
    public static class SupplierServiceFactory
    {
        public static ISupplierService GetService(SupplierType type)
        {
            return type switch
            {
                SupplierType.supplier1 => new Supplier1Service(),
                SupplierType.supplier2 => new Supplier2Service(),
                SupplierType.supplier3 => new Supplier3Service(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
