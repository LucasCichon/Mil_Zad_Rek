using MilitaryProductsFlaggingSystem.Application.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Common;

namespace MilitaryProductsFlaggingSystem.Application.Services
{
    public interface ISupplierServiceFactory
    {
        ISupplierService CreateSupplierService(Supplier supplier);
    }
}