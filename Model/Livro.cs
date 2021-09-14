using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiVesp.Model
{
    [Table("livro")]
    public class Livro
    {
        [Key]
        [Column("idlivro")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int IdLivro { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O tamanho do nome deve ser de 10 ate 50")]
        public string Nome { get; set; }

        [Column("autor")]
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O tamanho do nome do autor deve ser de 10 ate 50")]
        public string Autor { get; set; }

        [Column("idamigo")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int IdAmigo { get; set; }


    }
}
