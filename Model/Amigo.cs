using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaApiVesp.Model
{
    [Table("amigo")]
    public class Amigo
    {
        [Key]
        [Column("idamigo")]
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int IdAmigo { get; set; }

        [Column("nome")]
        [Required]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "O tamanho do nome deve ser de 10 ate 50")]
        public string Nome { get; set; }

        [Column("idcidade")]
        //[Required(ErrorMessage ="O IdCidade é obrigatório")]      
        public int IdCidade { get; set; }


    }
}
