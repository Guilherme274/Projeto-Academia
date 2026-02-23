using Microsoft.AspNetCore.Identity;

namespace TrackFocus.Domain.Entities
{
    public class Usuario : IdentityUser
    {
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;
    }
}