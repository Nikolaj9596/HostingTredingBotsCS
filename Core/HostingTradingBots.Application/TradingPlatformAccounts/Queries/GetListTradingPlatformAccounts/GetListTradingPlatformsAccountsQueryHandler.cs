using AutoMapper;
using AutoMapper.QueryableExtensions;
using HostingTradingBots.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Queries.GetListTradingPlatformAccounts
{
    public class GetListTradingPlatformsAccountsQueryHandler
      : IRequestHandler<GetListTradingPlatformsAccountsQuery, ListTradingPlatformsAccountsVm>
    {
        private readonly ITradingPlatformAccountDBContext _dbContext;
        private readonly IMapper _mapper;
        public GetListTradingPlatformsAccountsQueryHandler(ITradingPlatformAccountDBContext dBContext,
            IMapper mapper) => (_dbContext, _mapper) = (dBContext, mapper);

        public async Task<ListTradingPlatformsAccountsVm> Handle(GetListTradingPlatformsAccountsQuery request,
            CancellationToken cancellationToken)
        {
            var listTradingPlatformsAccountsQuery = await _dbContext.TradingPlatformsAccounts
              .ProjectTo<TradingPlatformsAccountsLookupDto>(_mapper.ConfigurationProvider)
              .ToListAsync(cancellationToken);

            return new ListTradingPlatformsAccountsVm { TradingPlatformsAccounts = listTradingPlatformsAccountsQuery };
        }
    }
}
