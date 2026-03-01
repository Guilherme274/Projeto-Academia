using System.ComponentModel.DataAnnotations.Schema;

namespace TrackFocus.Domain.Entities
{
    public class DetalheMusculacao
    {
        [Column("cd_id", TypeName = "int")]
        public int Id { get; set; }
        [Column("qt_repeticoes", TypeName = "int")]
        public int? NumRepeticoes { get; set; }
        [Column("qt_series", TypeName = "int")]
        public int? NumSeries { get; set; }
        [Column("cd_serieId", TypeName = "int")]
        public int? SerieId { get; set; }
        [ForeignKey(nameof(SerieId))]
        public Serie? Serie { get; set; }
        public ICollection<Exercicio> Exercicios { get; set; }
    }
}