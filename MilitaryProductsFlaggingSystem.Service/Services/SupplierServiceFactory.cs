using MilitaryProductsFlaggingSystem.Application.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Common;
using MilitaryProductsFlaggingSystem.Domain.Interfaces;
using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier1;
using MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier3;

namespace MilitaryProductsFlaggingSystem.Application.Services
{
    public class SupplierServiceFactory : ISupplierServiceFactory
    {
        private readonly IFileRepository<Offer> _s1Repo;
        private readonly IFileRepository<Domain.Model.Dtos.Supplier2.Product> _s2Repo;
        private readonly IFileRepository<Produkt> _s3Repo;
        private readonly IFlaggedItemsRepository _flaggedItemsRepository;

        public SupplierServiceFactory(IFileRepository<MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier1.Offer> s1Repo,
            IFileRepository<MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier2.Product> s2Repo,
            IFileRepository<MilitaryProductsFlaggingSystem.Domain.Model.Dtos.Supplier3.Produkt> s3Repo,
            IFlaggedItemsRepository flaggedItemsRepository)
        {
            _s1Repo = s1Repo;
            _s2Repo = s2Repo;
            _s3Repo = s3Repo;
            _flaggedItemsRepository = flaggedItemsRepository;
        }
        public ISupplierService CreateSupplierService(Supplier supplier)
        {
            return supplier switch
            {
                Supplier.Supplier1 => new Supplier1Service(_s1Repo, _flaggedItemsRepository),
                Supplier.Supplier2 => new Supplier2Service(_s2Repo, _flaggedItemsRepository),
                Supplier.Supplier3 => new Supplier3Service(_s3Repo, _flaggedItemsRepository),
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }
}
