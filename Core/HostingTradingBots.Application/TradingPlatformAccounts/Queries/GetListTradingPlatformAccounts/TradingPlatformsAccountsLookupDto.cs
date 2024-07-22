using HostingTradingBots.Application.Common.Mappings;

namespace HostingTradingBots.Application.TradingPlatformAccounts.Queries.GetListTradingPlatformAccounts
{
    public class TradingPlatformsAccountsLookupDto : IMapWith<TradingPlatformAccount.Domain.TradingPlatformAccount>
    {
        public Guid Id { get; set; }
        public Guid TradingPlatformId { get; set; }
        public Guid UserId { get; set; }
        public Boolean IsActive { get; set; }
        public String ApiKey { get; set; }
        public String? TestApiKey { get; set; }

        public void Mapping(AutoMapper.Profile profile)
        {
            profile.CreateMap<TradingPlatformAccount.Domain.TradingPlatformAccount, TradingPlatformsAccountsLookupDto>()
              .ForMember(tradingPlatformAccountDto => tradingPlatformAccountDto.Id,
                  opt => opt.MapFrom(profile => profile.Id))
              .ForMember(tradingPlatformAccountDto => tradingPlatformAccountDto.TradingPlatformId,
                  opt => opt.MapFrom(profile => profile.TradingPlatformId))
              .ForMember(tradingPlatformAccountDto => tradingPlatformAccountDto.UserId,
                  opt => opt.MapFrom(profile => profile.UserId))
              .ForMember(tradingPlatformAccountDto => tradingPlatformAccountDto.IsActive,
                  opt => opt.MapFrom(profile => profile.IsActive));
        }
    }
}
