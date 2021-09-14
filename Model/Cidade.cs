using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiVesp.Model
{
    [Table("cidade")]
    public class Cidade
    {
        [Key]
        [Column("idcidade")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int IdCidade { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O tamanho do nome deve ser de 10 ate 50")]
        public string Nome { get; set; }

        [Column("uf")]
        [Required]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "O tamanho da UF deve ser 2 caracteres")]
        public string Uf { get; set; }


    }
}
