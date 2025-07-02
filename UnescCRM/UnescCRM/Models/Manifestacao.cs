using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace UnescCRM.Models
{
    [Table("manifestacao")]
    public class Manifestacao
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("usuario_id")]
        public int UsuarioId { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("tipo")]
        public int Tipo { get; set; }
        /* 0 - Falha
           1 - Evolução */

        [Column("situacao")]
        public int Situacao { get; set; }
        /* 0 - Em aberto
           1 - Em andamento
           2 - Concluída */

        [Column("data")]
        public DateTime Data { get; set; }

        [Column("data_solucao")]
        public DateTime? DataSolucao { get; set; }

        [JsonIgnore]
        public Usuario? Usuario { get; set; }
    }
}
