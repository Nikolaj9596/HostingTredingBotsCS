using System.Threading.Tasks;
using System.Threading;
using System;
using MediatR;
using Profile.Domain;
using Profile.Application.Interfaces;
using Profile.Application.Common.Exceptions; 
using Microsoft.EntityFrameworkCore;

namespace Profile.Application.Profiles.Commands.UpdateProfile
{
  public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, Unit>
  {
    private readonly IProfileDBContext _dbContext;

    public UpdateProfileCommandHandler(IProfileDBContext dBContext) =>
      _dbContext = dBContext;

    public async Task<Unit> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
    {
      var entity = 
        await _dbContext.Profiles.FirstOrDefaultAsync(profile =>
            profile.Id == request.Id, cancellationToken);

      if(entity == null || entity.UserId != request.UserId)
      {
        throw new NotFoundException(nameof(Profile.Domain.Profile), request.Id);
      }

      entity.FirstName = request.FirstName;
      entity.LastName = request.LastName;
      entity.MiddleName = request.MiddleName;
      entity.Avatar = request.Avatar;
      entity.DateBirthday = request.DateBirthday;
      entity.UpdatedAt = DateTime.Now;


      await _dbContext.SaveChangesAsync(cancellationToken);
      return Unit.Value;
    }
  }
}
