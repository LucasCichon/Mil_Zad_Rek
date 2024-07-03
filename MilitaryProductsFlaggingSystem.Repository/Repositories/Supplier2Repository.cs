using MilitaryProductsFlaggingSystem.Common;
using MilitaryProductsFlaggingSystem.Common.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Common;
using MilitaryProductsFlaggingSystem.Domain.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier2;

namespace MilitaryProductsFlaggingSystem.Infrastructure.Repositories
{
    public class Supplier2Repository : IFileRepository<Product>
    {
        public Supplier supplier => Supplier.Supplier2;

        public Either<IError, List<string>> GetFilesContent()
        {
            throw new NotImplementedException();
        }

        public Either<IError, List<Product>> GetFilesProducts()
        {
            throw new NotImplementedException();
        }
    }
}
