using MilitaryProductsFlaggingSystem.Common;
using MilitaryProductsFlaggingSystem.Common.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Common;
using MilitaryProductsFlaggingSystem.Domain.Model;


namespace MilitaryProductsFlaggingSystem.Domain.Interfaces
{
    public interface IFlaggedItemsRepository
    {
        Either<IError, List<FinalProduct>> GetFlaggedProducts(Supplier supplier);
        IOption<IError> SetFlaggedProducts(Supplier supplier, List<string> productsIds);
        IOption<IError> RemoveFlaggedProducts(Supplier supplier, List<string> productsIds);
    }
}
