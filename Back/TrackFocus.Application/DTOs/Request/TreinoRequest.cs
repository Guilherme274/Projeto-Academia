using System.ComponentModel.DataAnnotations;

namespace TrackFocus.Application.DTOs.Request
{
    public record TreinoRequest([Required] int Id, [Required] int UserId);
}