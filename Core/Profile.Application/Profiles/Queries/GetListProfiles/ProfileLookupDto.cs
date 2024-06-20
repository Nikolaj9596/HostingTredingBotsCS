using System;
using MediatR;
using AutoMapper;
using Profile.Domain;
using Profile.Application.Common.Mappings;

namespace Profile.Application.Profiles.Queries.GetListProfiles
{
  public class ProfileLookupDto : IMapWith<Profile.Domain.Profile>
  {
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public byte[] Avatar { get; set; }

    public void Mapping(AutoMapper.Profile profile)
    {
      profile.CreateMap<Profile.Domain.Profile, ProfileLookupDto>()
        .ForMember(profileDto => profileDto.Id,
            opt => opt.MapFrom(profile => profile.Id))
        .ForMember(profileDto => profileDto.FirstName,
            opt => opt.MapFrom(profile => profile.FirstName))
        .ForMember(profileDto => profileDto.LastName,
            opt => opt.MapFrom(profile => profile.LastName))
        .ForMember(profileDto => profileDto.MiddleName,
            opt => opt.MapFrom(profile => profile.MiddleName))
        .ForMember(profileDto => profileDto.Avatar,
            opt => opt.MapFrom(profile => profile.Avatar));
    }
  }
}
