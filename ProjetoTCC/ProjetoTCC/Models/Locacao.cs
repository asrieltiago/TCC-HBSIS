using SistemaLocacaoHBSIS.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    [Table("Locacoes")]
    public class Locacao : UserControls
    {
        [Key]
        public int Id { get; set; }            
        public virtual RegistroVeiculo RegistroVeiculo { get; set; }
        public virtual Colaborador Colaborador { get; set; }        
        public virtual Periodo Periodo { get; set; }        
        public virtual TermoLocacao TermoLocacao { get; set; }        
        public bool AceiteTermo { get; set; }
        public StatusLocacao Status { get; set; }

    }
}