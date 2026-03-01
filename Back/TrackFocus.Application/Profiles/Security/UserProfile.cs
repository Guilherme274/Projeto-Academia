using AutoMapper;
using TrackFocus.Application.DTOs.Request;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.Profiles.Security
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterRequest, User>();
            CreateMap<User, LoginResponse>();
        }
    }
}