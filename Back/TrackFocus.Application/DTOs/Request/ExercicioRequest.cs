using System.ComponentModel.DataAnnotations;

namespace TrackFocus.Application.DTOs.Request
{
    public record ExercicioRequest([Required] Guid Id, [Required] string Nome, [Required] string Tipo);
}