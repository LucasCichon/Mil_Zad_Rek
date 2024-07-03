using MilitaryProductsFlaggingSystem.Application.Errors;
using MilitaryProductsFlaggingSystem.Common;
using MilitaryProductsFlaggingSystem.Common.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model;


namespace MilitaryProductsFlaggingSystem.Application.Interfaces
{
    public interface ISupplierService
    {
        IOption<IError> FlaggProducts(Dictionary<string, bool> id_isFlagged);
        Either<IError, List<FinalProduct>> GetProducts(bool withFlagged);
    }
}
