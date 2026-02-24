using System.Reflection.Metadata;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.Service
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}