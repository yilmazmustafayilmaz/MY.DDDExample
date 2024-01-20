using Application.Common.CQ;
using Application.UseCase.Packages.DTOs;
using Domain.Aggragate.Packages;
using Domain.Common;
using Domain.Events.Packages;

namespace Application.UseCase.Packages.CQHandler;

public sealed partial class PackageCQHandler : Handler<IPackageService>,
    IRequestHandler<Insert<PackageDto>, bool>,
    IRequestHandler<Update<PackageDto>>,
    IRequestHandler<Delete<PackageDto, int>>
{
    public PackageCQHandler(IUnitOfWork unitOfWork) : base(unitOfWork) { }

    public async Task<bool> Handle(Insert<PackageDto> request, CancellationToken cancellationToken)
    {
        using (var transaction = UnitOfWork.BeginTransaction())
        {
            try
            {
                Package package = new() { Name = request.dto.Name };
                Service.Insert(package);
                package.AddDomainEvent(new PackageCreatedEvent(package));
                await UnitOfWork.CommitAsync(cancellationToken);
                await transaction.CommitAsync();
                return await Success();
            }
            catch (System.Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }

    public Task Handle(Update<PackageDto> request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task Handle(Delete<PackageDto, int> request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
