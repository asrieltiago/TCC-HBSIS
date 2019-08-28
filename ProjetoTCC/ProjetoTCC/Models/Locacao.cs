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

        //[ForeignKey("IdRegistroVeiculo")]
        public virtual RegistroVeiculo RegistroVeiculo { get; set; }
        //public int IdRegistroVeiculo { get; set; }

        //[ForeignKey("IdColaborador")]
        public virtual Colaborador Colaborador { get; set; }
        //public int IdColaborador { get; set; }

        //[ForeignKey("IdPeriodo")]
        public virtual Periodo Periodo { get; set; }
        //public int IdPeriodo { get; set; }

        //[ForeignKey("IdTermo")]
        public virtual TermoLocacao TermoLocacao { get; set; }
        //public int IdTermo { get; set; }

        public bool AceiteTermo { get; set; }

        public Enums.StatusLocacao Status { get; set; }

    }
}