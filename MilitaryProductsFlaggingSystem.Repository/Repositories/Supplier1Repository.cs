using MilitaryProductsFlaggingSystem.Common;
using MilitaryProductsFlaggingSystem.Common.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Common;
using MilitaryProductsFlaggingSystem.Domain.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier1;
using MilitaryProductsFlaggingSystem.Infrastructure.Converters;

namespace MilitaryProductsFlaggingSystem.Infrastructure.Repositories
{
    public class Supplier1Repository : IFileRepository<Offer>
    {
        private readonly IProductsConverter _productsConverter;

        public Supplier supplier => Supplier.Supplier1;

        public Supplier1Repository(IProductsConverter productsConverter)
        {
            _productsConverter = productsConverter;
        }
        
        public Either<IError, List<Offer>> GetFilesProducts()
        {
            return GetFilesContent().Match(products =>
            {
                return Either<IError, List<Offer>>.Success(_productsConverter.ConvertProducts<Offer>(products));
            },
            error => Either<IError, List<Offer>>.Error(error));
        }

        public Either<IError, List<string>> GetFilesContent()
        {
            throw new NotImplementedException();
        }

    }
}
