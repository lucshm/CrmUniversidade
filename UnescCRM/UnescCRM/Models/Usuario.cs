using System.ComponentModel.DataAnnotations.Schema;

namespace UnescCRM.Models
{
    [Table("usuario")]
    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("login")]
        public int Login { get; set; }

        [Column("senha")]
        public string Senha { get; set; }

        [Column("tipo")]
        public int Tipo { get; set; }
        /* 0 - Normal
           1 - Adm */
        [Column("nome")]
        public string Nome { get; set; }

    }
}
