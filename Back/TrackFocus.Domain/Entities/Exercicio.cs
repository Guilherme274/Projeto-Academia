using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackFocus.Domain.Entities
{
    [Table("Exercicio")]
    public class Exercicio
    {
        [Column("cd_id", TypeName = "int")]
        public int Id { get; set; }
        [Column("nm_exercicio", TypeName = "varchar(100)")]
        public string Nome { get; set; } = string.Empty;
        [Column("cd_categoriaId", TypeName = "int")]
        public int CategoriaId { get; set; }
        [ForeignKey(nameof(CategoriaId))]
        public Categoria Categoria { get; set; }
        public ICollection<Treino> Treinos { get; set; }
        public ICollection<DetalheMusculacao> Detalhes { get; set; }
    }
}