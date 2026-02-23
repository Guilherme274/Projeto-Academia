using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace TrackFocus.Application.DTOs.Request
{
    public record RegisterRequest
    (
        [Required]
        string Username,
        [Required]
        [DataType(DataType.Password)]
        string Password,
        [Required]
        [property:Compare("Password")]
        string RepeatPassword,
        [Required]
        DateTime DataNascimento
    );
}