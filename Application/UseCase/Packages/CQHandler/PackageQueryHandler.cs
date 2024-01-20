using Application.Common.CQ;
using Application.UseCase.Packages.DTOs;
using Domain.Aggragate.Packages;

namespace Application.UseCase.Packages.CQHandler;

public sealed partial class PackageCQHandler :
    IRequestHandler<GetById<PackageDto, int>, PackageDto>
{
    public Task<PackageDto> Handle(GetById<PackageDto, int> request, CancellationToken cancellationToken)
    {
        Package package = Service.Get(request.Id);
        PackageDto packageDto = new(Id: package.Id, Name: package.Name);
        return Success(packageDto);
    }
}
