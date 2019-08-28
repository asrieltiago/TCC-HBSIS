using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    [Table("Colaboradores")]
    public class Colaborador
    {        
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Pcd { get; set; }
        public bool TrabalhoNoturno { get; set; }
        public bool Carona { get; set; }
        public bool ResideFora { get; set; }
    }
}