using AutoMapper;

namespace HostingTradingBots.Application.Common.Mappings
{
  public interface IMapWith<T>
  {
    void Mapping(AutoMapper.Profile profile) =>
      profile.CreateMap(typeof(T), GetType());
  }
}
