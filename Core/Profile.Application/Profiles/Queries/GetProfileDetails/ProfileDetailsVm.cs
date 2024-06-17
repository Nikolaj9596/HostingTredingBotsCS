using System;
using MediatR;
using Profile.Application.Common.Mappings;
using Profile.Domain;
using AutoMapper;

namespace Profile.Application.Profiles.Queries.GetProfileDetails
{
  public class ProfileDetailsVm : IMapWith<Profile.Domain.Profile>
  {
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public DateTime DateBirthday { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? ArchivedAt { get; set; }
    public byte[] Avatar { get; set; }

    public void Mapping(AutoMapper.Profile profile)
    {
      profile.CreateMap<Profile.Domain.Profile, ProfileDetailsVm>()
        .ForMember(profileVm => profileVm.Id,
            opt => opt.MapFrom(profile => profile.Id))
        .ForMember(profileVm => profileVm.UserId,
            opt => opt.MapFrom(profile => profile.UserId))
        .ForMember(profileVm => profileVm.FirstName,
            opt => opt.MapFrom(profile => profile.FirstName))
        .ForMember(profileVm => profileVm.LastName,
            opt => opt.MapFrom(profile => profile.LastName))
        .ForMember(profileVm => profileVm.MiddleName,
            opt => opt.MapFrom(profile => profile.MiddleName))
        .ForMember(profileVm => profileVm.DateBirthday,
            opt => opt.MapFrom(profile => profile.DateBirthday))
        .ForMember(profileVm => profileVm.Avatar,
            opt => opt.MapFrom(profile => profile.Avatar))
        .ForMember(profileVm => profileVm.CreatedAt,
            opt => opt.MapFrom(profile => profile.CreatedAt))
        .ForMember(profileVm => profileVm.UpdatedAt,
            opt => opt.MapFrom(profile => profile.UpdatedAt));
    }

  }
}
