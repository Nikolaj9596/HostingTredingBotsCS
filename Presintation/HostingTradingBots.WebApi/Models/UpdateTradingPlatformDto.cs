using AutoMapper;
using HostingTradingBots.Application.Common.Mappings;
using HostingTradingBots.Application.TradingPlatforms.Commands.UpdateTradingPlatform;

namespace HostingTradingBots.WebApi.Models
{
  public class UpdateTradingPlatformDto : IMapWith<UpdateTradingPlatformCommand>
  {
    public string Name { get; set; }
    public string SiteLink { get; set; }
    public bool IsActive { get; set; }
    public string? ReferralLink { get; set; }
    public string? ApiLink { get; set; }
    public string? TestApiLink { get; set; }
    public string? DocsLink { get; set; }
    public string? Icon { get; set; }

    public void Mappings(AutoMapper.Profile profile)
    {
      profile.CreateMap<UpdateTradingPlatformDto, UpdateTradingPlatformCommand>()
        .ForMember(tradingPlatformCommand => tradingPlatformCommand.Name,
            opt => opt.MapFrom(profileDto => profileDto.Name))
        .ForMember(tradingPlatformCommand => tradingPlatformCommand.SiteLink,
            opt => opt.MapFrom(profileDto => profileDto.SiteLink))
        .ForMember(tradingPlatformCommand => tradingPlatformCommand.IsActive,
            opt => opt.MapFrom(profileDto => profileDto.IsActive))
        .ForMember(tradingPlatformCommand => tradingPlatformCommand.ReferralLink,
            opt => opt.MapFrom(profileDto => profileDto.ReferralLink))
        .ForMember(tradingPlatformCommand => tradingPlatformCommand.ApiLink,
            opt => opt.MapFrom(profileDto => profileDto.ApiLink))
        .ForMember(tradingPlatformCommand => tradingPlatformCommand.DocsLink,
            opt => opt.MapFrom(profileDto => profileDto.DocsLink))
        .ForMember(tradingPlatformCommand => tradingPlatformCommand.Icon,
            opt => opt.MapFrom(profileDto => profileDto.Icon))
        .ForMember(tradingPlatformCommand => tradingPlatformCommand.TestApiLink,
            opt => opt.MapFrom(profileDto => profileDto.TestApiLink));
    }
  }
}
