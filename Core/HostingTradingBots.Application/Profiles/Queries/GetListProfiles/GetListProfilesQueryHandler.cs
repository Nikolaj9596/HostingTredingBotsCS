using AutoMapper;
using AutoMapper.QueryableExtensions;
using HostingTradingBots.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.Profiles.Queries.GetListProfiles
{
  public class GetListProfilesQueryHandler
    : IRequestHandler<GetListProfilesQuery, ListProfilesVm>
  {
    private readonly IProfileDBContext _dbContext;
    private readonly IMapper _mapper;
    public GetListProfilesQueryHandler(IProfileDBContext dBContext,
        IMapper mapper) => (_dbContext, _mapper) = (dBContext, mapper);

    public async Task<ListProfilesVm> Handle(GetListProfilesQuery request,
        CancellationToken cancellationToken)
    {
      var profilesQuery = await _dbContext.Profiles
        .Where(profile =>
          profile.UserId == request.UserId)
        .ProjectTo<ProfileLookupDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);

      return new ListProfilesVm { Profiles = profilesQuery };
    }
  }
}
