using AutoMapper;
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
        private IMapper _mapper;
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _mapper = mapper;
        }


        public async Task<string> RegisterUserAsync(RegisterRequest request)
        {
            var user = _mapper.Map<User>(request);

            IdentityResult result = await _userManager.CreateAsync(user,request.Password);

            if (!result.Succeeded)
                throw new ApplicationException("Erro ao criar Usuário");
            else
                return "Usuário criado.";
        }
        public async Task<LoginResponse> LoginUserAsync(LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);

                if (!result.Succeeded)
                    throw new ApplicationException("Usuário não autenticado");
                
                string token = _tokenService.GenerateToken(user);

                var response = _mapper.Map<LoginResponse>(user);
                
                return new LoginResponse(response.Id, response.Email, response.UserName, response.DataNascimento, token);
            }
            else
            {
                throw new ApplicationException("Email não reconhecido");
            }
        }
    }
}