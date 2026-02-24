using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.StaticAssets;
using TrackFocus.Application.DTOs.Request;
using TrackFocus.Application.DTOs.Response;
using TrackFocus.Application.Service;
using TrackFocus.Domain.Entities;

namespace TrackFocus.API.Endpoints
{
    public static class UserExtensions
    {
        public static void MapUserEndpoints(this WebApplication app)
        {
            app.MapPost("/register", async Task<IResult>(RegisterRequest request, IUserService userService) =>
            {
                RegisterResponse response = await userService.RegisterUserAsync(request);

                return Results.Created($"/register/{response.Id}", response);
            });

            app.MapPost("/login", async Task<string>(LoginRequest request, IUserService userService) =>
            {
                string token = await userService.LoginUserAsync(request);

                return token;
            });
        }
    }
}