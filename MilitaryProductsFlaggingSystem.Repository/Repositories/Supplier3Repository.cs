using MilitaryProductsFlaggingSystem.Common;
using MilitaryProductsFlaggingSystem.Common.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Common;
using MilitaryProductsFlaggingSystem.Domain.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier3;

namespace MilitaryProductsFlaggingSystem.Infrastructure.Repositories
{
    public class Supplier3Repository : IFileRepository<Produkt>
    {
        public Supplier supplier => Supplier.Supplier3;
        public Either<IError, List<string>> GetFilesContent()
        {
            throw new NotImplementedException();
        }

        public Either<IError, List<Produkt>> GetFilesProducts()
        {
            throw new NotImplementedException();
        }
    }
}
