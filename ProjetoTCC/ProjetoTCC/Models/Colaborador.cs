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
        public bool Pcd { get; set; } = false;       
        public bool TrabalhoNoturno { get; set; } = false;
        public bool Carona { get; set; } = false;
        public bool ResideFora { get; set; } = false;
    }
}