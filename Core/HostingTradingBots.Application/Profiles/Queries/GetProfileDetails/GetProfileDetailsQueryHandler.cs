using AutoMapper;
using HostingTradingBots.Application.Interfaces;
using HostingTradingBots.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.Profiles.Queries.GetProfileDetails
{
  public class GetProfileDetailsQueryHandler
    : IRequestHandler<GetProfileDetailsQuery, ProfileDetailsVm>
  {
    private readonly IProfileDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetProfileDetailsQueryHandler(IProfileDBContext dBContext,
        IMapper mapper) => (_dbContext, _mapper) = (dBContext, mapper);

    public async Task<ProfileDetailsVm> Handle(GetProfileDetailsQuery request,
        CancellationToken cancellationToken)
    {
      var entity = await _dbContext.Profiles
        .FirstOrDefaultAsync(profile =>
          profile.Id == request.Id, cancellationToken);


      if (entity == null || entity.UserId != request.UserId)
      {
        throw new NotFoundException(nameof(Profile.Domain.Profile), request.Id);
      }
      return _mapper.Map<ProfileDetailsVm>(entity);
    }
  }
}
