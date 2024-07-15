using HostingTradingBots.Application.Common.Mappings;

namespace HostingTradingBots.Application.TradingPlatforms.Queries.GetListTradingPlatforms
{
  public class TradingPlatformsLookupDto : IMapWith<TradingPlatform.Domain.TradingPlatform>
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public string? Icon { get; set; }

    public void Mapping(AutoMapper.Profile profile)
    {
      profile.CreateMap<TradingPlatform.Domain.TradingPlatform, TradingPlatformsLookupDto>()
        .ForMember(tradingPlatformDto => tradingPlatformDto.Id,
            opt => opt.MapFrom(profile => profile.Id))
        .ForMember(tradingPlatformDto => tradingPlatformDto.Name,
            opt => opt.MapFrom(profile => profile.Name))
        .ForMember(tradingPlatformDto => tradingPlatformDto.IsActive,
            opt => opt.MapFrom(profile => profile.IsActive))
        .ForMember(tradingPlatformDto => tradingPlatformDto.Icon,
            opt => opt.MapFrom(profile => profile.Icon));
    }
  }
}
