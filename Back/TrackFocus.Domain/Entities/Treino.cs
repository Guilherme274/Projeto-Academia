using System.ComponentModel.DataAnnotations.Schema;

namespace TrackFocus.Domain.Entities
{
    public class Treino
    {
        public int Id { get; set; }
        [Column("cd_userId", TypeName = "varchar(30)")]
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public ICollection<Exercicio> Exercicios { get; set; }
    }
}