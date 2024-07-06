using AutoMapper;
using HostingTradingBots.Application.Interfaces;
using HostingTradingBots.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HostingTradingBots.Application.TradingPlatforms.Queries.GetTradingPlatformDetails
{
  public class GetTradingPlatformDetailsQueryHandler
    : IRequestHandler<GetTradingPlatformDetailsQuery, TradingPlatformDetailsVm>
  {
    private readonly ITradingPlatrformDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetTradingPlatformDetailsQueryHandler(ITradingPlatrformDBContext dBContext,
        IMapper mapper) => (_dbContext, _mapper) = (dBContext, mapper);

    public async Task<TradingPlatformDetailsVm> Handle(GetTradingPlatformDetailsQuery request,
        CancellationToken cancellationToken)
    {
      var entity = await _dbContext.TradingPlatforms
        .FirstOrDefaultAsync(profile =>
          profile.Id == request.Id, cancellationToken);


      if (entity == null)
      {
        throw new NotFoundException(nameof(TradingPlatform.Domain.TradingPlatform), request.Id);
      }
      return _mapper.Map<TradingPlatformDetailsVm>(entity);
    }
  }
}
