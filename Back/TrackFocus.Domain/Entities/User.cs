using Microsoft.AspNetCore.Identity;

namespace TrackFocus.Domain.Entities
{
    public class User : IdentityUser
    {
        public DateTime DataNascimento { get; set; } = DateTime.MinValue;
        public ICollection<Treino> Treinos { get; set; }
    }
}