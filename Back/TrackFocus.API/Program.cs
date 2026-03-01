using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TrackFocus.Application.Service;
using TrackFocus.Domain.Entities;
using TrackFocus.Infraestructure.Data;
using TrackFocus.Infraestructure.Service;
using TrackFocus.API.Endpoints;
using TrackFocus.Infraestructure.Data.Security;
using TrackFocus.Application.Profiles.Security;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Pegando Connection String
string connString = builder.Configuration.GetConnectionString("DbConnection");

// Adicionando Autor mapper passando Assembly do Profile 
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

// Implementando Injeção de Dependência de Interface para Serviço
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();

// Adicionando DbContext
builder.Services.AddDbContext<SecurityContext>(options =>
{
    options.UseMySql(connString,ServerVersion.AutoDetect(connString));
});
// Criando Identity, direcionando para IdentityUser e em qual contexto deve ser armazenado
builder.Services.AddIdentity<User,IdentityRole>()
                .AddEntityFrameworkStores<SecurityContext>()
                .AddDefaultTokenProviders();
// Adicionando Contexto para lidar com Entidades de Negócio 
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseMySql(connString, ServerVersion.AutoDetect(connString));
});

// Adicionando Autenticação seguindo esquema padrão, com token recebendo parâmetros de validação
builder.Services.AddAuthentication(options =>
{
   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"{builder.Configuration["JwtSettings:Secret"]}")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew = TimeSpan.Zero
    };
});

// Adicionando Cross Origin Resource Sharing
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// Configurando Permissões do CORS
app.UseCors( options =>
{
   options.AllowAnyHeader()
          .AllowAnyMethod()
          .AllowAnyOrigin();
});

app.UseHttpsRedirection();
// Dizendo para o App que foi construído que ele pode usar autenticação
app.UseAuthentication();
// Mapeando End Point seguind padrões Minimal APIs
app.MapUserEndpoints();
// app.UseAuthorization();

app.Run();