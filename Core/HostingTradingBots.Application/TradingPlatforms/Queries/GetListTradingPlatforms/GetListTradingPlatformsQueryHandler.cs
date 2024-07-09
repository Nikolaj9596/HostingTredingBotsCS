using AutoMapper;
using AutoMapper.QueryableExtensions;
using HostingTradingBots.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.TradingPlatforms.Queries.GetListTradingPlatforms
{
  public class GetListTradingPlatformsQueryHandler
    : IRequestHandler<GetListTradingPlatformsQuery, ListTradingPlatformsVm>
  {
    private readonly ITradingPlatformDBContext _dbContext;
    private readonly IMapper _mapper;
    public GetListTradingPlatformsQueryHandler(ITradingPlatformDBContext dBContext,
        IMapper mapper) => (_dbContext, _mapper) = (dBContext, mapper);

    public async Task<ListTradingPlatformsVm> Handle(GetListTradingPlatformsQuery request,
        CancellationToken cancellationToken)
    {
      var tradingPlatformsQuery = await _dbContext.TradingPlatforms
        .ProjectTo<TradingPlatformsLookupDto>(_mapper.ConfigurationProvider)
        .ToListAsync(cancellationToken);

      return new ListTradingPlatformsVm { TradingPlatforms = tradingPlatformsQuery };
    }
  }
}
