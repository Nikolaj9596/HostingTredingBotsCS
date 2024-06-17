using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Profile.Application.Interfaces;
using Profile.Application.Common.Exceptions;
using Profile.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Profile.Application.Profiles.Queries.GetListProfiles
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
