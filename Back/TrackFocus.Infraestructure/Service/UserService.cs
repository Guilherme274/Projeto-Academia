using Microsoft.AspNetCore.Identity;
using TrackFocus.Application.DTOs.Request;
using TrackFocus.Application.DTOs.Response;
using TrackFocus.Application.Service;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Infraestructure.Service
{
    public class UserService : IUserService
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ITokenService _tokenService;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }


        public async Task<RegisterResponse> RegisterUserAsync(RegisterRequest request)
        {
            var user = new User
            {
              UserName = request.Username,
              DataNascimento = request.DataNascimento  
            };

            IdentityResult result = await _userManager.CreateAsync(user,request.Password);

            if (!result.Succeeded)
                throw new ApplicationException("Erro ao criar Usuário");
            else
                return new RegisterResponse(user.Id, request.Username, request.DataNascimento);
        }
        public async Task<string> LoginUserAsync(LoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false, false);

            if (!result.Succeeded)
                throw new ApplicationException("Usuário não autenticado");
            
            var user = await _userManager.FindByNameAsync(request.Username);

            string token = _tokenService.GenerateToken(user);
            
            return token;
        }
    }
}