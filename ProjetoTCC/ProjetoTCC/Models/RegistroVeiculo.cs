using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    [Table("RegistroVeiculos")]
    public class RegistroVeiculo : UserControls
    {
        [Key]
        public int Id { get; set; }
        public string Placa { get; set; }
        public virtual Modelo Modelo { get; set; }
        public virtual TipoCor Cor { get; set; }
    }
}