using MilitaryProductsFlaggingSystem.Common;
using MilitaryProductsFlaggingSystem.Common.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Common;
using MilitaryProductsFlaggingSystem.Domain;


namespace MilitaryProductsFlaggingSystem.Domain.Interfaces
{
    public interface IFileRepository<T>
    {
        Supplier supplier { get; }
        //Returns the contents of a given suppliers's latest files. I assume that for a given supplier, only the latest files with the current offer will be available.
        Either<IError, List<string>> GetFilesContent();
        Either<IError, List<T>> GetFilesProducts();

    }
}
