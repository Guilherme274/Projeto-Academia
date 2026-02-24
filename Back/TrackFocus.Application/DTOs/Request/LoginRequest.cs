using System.ComponentModel.DataAnnotations;

namespace TrackFocus.Application.DTOs.Request
{
    public record LoginRequest([Required] string Username,[Required] DateTime DataNascimento);
}