using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class Colaborador
    {
        [Key]
        public int IdColaborador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Pcd { get; set; }
        public bool TrabalhoNoturno { get; set; }
        public bool Carona { get; set; }
        public bool Idoso { get; set; }
        public bool ResideFora { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
       
    }
}