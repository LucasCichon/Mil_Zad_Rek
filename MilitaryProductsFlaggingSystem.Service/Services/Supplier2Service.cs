using MilitaryProductsFlaggingSystem.Application.Converters;
using MilitaryProductsFlaggingSystem.Application.Converters.Interfaces;
using MilitaryProductsFlaggingSystem.Application.Helpers;
using MilitaryProductsFlaggingSystem.Application.Interfaces;
using MilitaryProductsFlaggingSystem.Common;
using MilitaryProductsFlaggingSystem.Common.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Common;
using MilitaryProductsFlaggingSystem.Domain.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model;
using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier2;

namespace MilitaryProductsFlaggingSystem.Application.Services
{
    public class Supplier2Service : ISupplierService
    {
        private readonly IFileRepository<Product> _fileRepository;
        private readonly IFlaggedItemsRepository _flaggedItemsRepository;
        private readonly Supplier _supplier = Supplier.Supplier2;
        private readonly IFinalProductConverter<Product> _finalProductConverter;

        public Supplier2Service(IFileRepository<Product> fileRepository, IFlaggedItemsRepository flaggedItemsRepository)
        {
            _fileRepository = fileRepository;
            _flaggedItemsRepository = flaggedItemsRepository;
            _finalProductConverter = new Supplier2FinalProductConverter();
        }
        public IOption<IError> FlaggProducts(Dictionary<string, bool> id_isFlagged)
        {
            throw new NotImplementedException();
        }

        public Either<IError, List<FinalProduct>> GetProducts(bool withFlagged)
        {
            return withFlagged ? GetFlaggedProducts() : GetProductsOnlyFromFile();
        }

        private Either<IError, List<FinalProduct>> GetProductsOnlyFromFile()
        {
            return _fileRepository.GetFilesProducts().Match(offers =>
            {
                return Either<IError, List<FinalProduct>>.Success(_finalProductConverter.Convert(offers));
            }, Either<IError, List<FinalProduct>>.Error);


        }
        private Either<IError, List<FinalProduct>> GetFlaggedProducts()
        {
            return _fileRepository.GetFilesProducts().Match(offers =>
            {
                return Either<IError, List<FinalProduct>>.Success(_finalProductConverter.Convert(offers)).Match((finalFromFile) =>
                {
                    return _flaggedItemsRepository.GetFlaggedProducts(_supplier).Match(flagged => {
                        return Either<IError, List<FinalProduct>>.Success(FinalProductHelper.JoinProducts(finalFromFile, flagged));
                    }
                    , Either<IError, List<FinalProduct>>.Error);
                }, Either<IError, List<FinalProduct>>.Error);
            }, Either<IError, List<FinalProduct>>.Error);
        }
    }
}
