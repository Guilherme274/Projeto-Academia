using TrackFocus.Application.DTOs.Request;
using TrackFocus.Application.DTOs.Response;

namespace TrackFocus.Application.Service
{
    public interface IUserService
    {
        public Task<RegisterResponse> RegisterUserAsync(RegisterRequest resquest);
        public Task<string>LoginUserAsync(LoginRequest request);
    }
}