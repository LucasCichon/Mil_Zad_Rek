using MilitaryProductsFlaggingSystem.Common;
using MilitaryProductsFlaggingSystem.Common.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Common;
using MilitaryProductsFlaggingSystem.Domain.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model;


namespace MilitaryProductsFlaggingSystem.Infrastructure.Repositories
{
    public class FlaggedItemsRepository : IFlaggedItemsRepository
    {
        public Either<IError, List<FinalProduct>> GetFlaggedProducts(Supplier supplier)
        {
            throw new NotImplementedException();
        }

        public IOption<IError> RemoveFlaggedProducts(Supplier supplier, List<string> productsIds)
        {
            throw new NotImplementedException();
        }

        public IOption<IError> SetFlaggedProducts(Supplier supplier, List<string> productsIds)
        {
            throw new NotImplementedException();
        }
    }
}
