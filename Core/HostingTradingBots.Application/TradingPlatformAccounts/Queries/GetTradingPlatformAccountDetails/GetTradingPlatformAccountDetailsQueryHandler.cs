using AutoMapper;
using HostingTradingBots.Application.Interfaces;
using HostingTradingBots.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.TradingPlatformsAccounts.Queries.GetTradingPlatformAccountDetails
{
    public class GetTradingPlatformAccountDetailsQueryHandler
      : IRequestHandler<GetTradingPlatformAccountDetailsQuery, TradingPlatformAccountDetailsVm>
    {
        private readonly ITradingPlatformAccountDBContext _dbContext;
        private readonly IMapper _mapper;

        public GetTradingPlatformAccountDetailsQueryHandler(ITradingPlatformAccountDBContext dBContext,
            IMapper mapper) => (_dbContext, _mapper) = (dBContext, mapper);

        public async Task<TradingPlatformAccountDetailsVm> Handle(GetTradingPlatformAccountDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.TradingPlatformsAccounts
              .FirstOrDefaultAsync(tradingPlatformAccount =>
                tradingPlatformAccount.Id == request.Id, cancellationToken);


            if (entity == null)
            {
                throw new NotFoundException(nameof(TradingPlatformAccount.Domain.TradingPlatformAccount), request.Id);
            }
            return _mapper.Map<TradingPlatformAccountDetailsVm>(entity);
        }
    }
}
