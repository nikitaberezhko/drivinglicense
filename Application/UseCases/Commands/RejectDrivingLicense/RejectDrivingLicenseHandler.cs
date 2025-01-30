using Application.Ports.Postgres;
using Domain.SharedKernel.Errors;
using FluentResults;
using MediatR;

namespace Application.UseCases.Commands.RejectDrivingLicense;

public class RejectDrivingLicenseHandler(
    IDrivingLicenseRepository drivingLicenseRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<RejectDrivingLicenseRequest, Result>
{
    public async Task<Result> Handle(RejectDrivingLicenseRequest request, CancellationToken cancellationToken)
    {
        var license = await drivingLicenseRepository.GetById(request.DrivingLicenseId);
        if (license is null) return Result.Fail(new NotFound("Driving license not found"));
        
        license.Reject();
        
        drivingLicenseRepository.Update(license);
        await unitOfWork.Commit();
        
        return Result.Ok();
    }
}