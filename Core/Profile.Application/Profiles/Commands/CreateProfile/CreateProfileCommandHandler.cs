using System.Threading.Tasks;
using System.Threading;
using System;
using MediatR;
using Profile.Domain;
using Profile.Application.Interfaces;

namespace Profile.Application.Profiles.Commands.CreateProfile
{
  public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, Guid>
  {
    private readonly IProfileDBContext _dbContext;

    public CreateProfileCommandHandler(IProfileDBContext dBContext) =>
      _dbContext = dBContext;

    public async Task<Guid> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
    {
      var profile = new Profile.Domain.Profile
      {
        Id = Guid.NewGuid(),
        UserId = request.UserId,
        FirstName = request.FirstName,
        LastName = request.LastName,
        MiddleName = request.MiddleName,
        Avatar = request.Avatar,
        DateBirthday = request.DateBirthday,
        CreatedAt = DateTime.Now,
        UpdatedAt = null

      };

      await _dbContext.Profiles.AddAsync(profile, cancellationToken);
      await _dbContext.SaveChangesAsync(cancellationToken);
      return profile.Id;
    }
  }

}
