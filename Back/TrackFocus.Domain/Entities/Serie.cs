using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackFocus.Domain.Entities
{
    public class Serie
    {
        [Key]
        [Column("cd_id", TypeName = "int")]
        public int Id { get; set; }
        [Column("qt_repeticoes", TypeName = "int")]
        public int Repeticoes { get; set; }
        [Column("qt_peso", TypeName = "int")]
        public int Peso { get; set; }
        public ICollection<DetalheMusculacao> Detalhes { get; set; }
    }
}