using System.ComponentModel.DataAnnotations;

namespace TrackFocus.Application.DTOs.Request
{
    public record LoginRequest([Required] string Username,[Required] string Password, [Required] DateTime DataNascimento);
}