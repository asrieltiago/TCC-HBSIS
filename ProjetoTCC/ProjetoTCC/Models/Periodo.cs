using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    [Table("Periodos")]
    public class Periodo
    {
        [Key]
        public int Id { get; set; }
        public int Vagas { get; set; }
        public bool Noturno { get; set; }
        public DateTime DataInicial { get; set; } = DateTime.Now;
        public DateTime DataFinal { get; set; } = DateTime.Now.AddMonths(+6);

        /// <summary>
        /// No POST deve-se informar TipoVeiculo.Codigo
        /// </summary>
        public virtual TipoVeiculo TipoVeiculo { get; set; }
    }
}