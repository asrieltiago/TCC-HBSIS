using ProjetoTCC.Enums;
using ProjetoTCC.Services;
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
        [Required(ErrorMessage ="O campo Valor não pode ser nulo.")]
        public int Valor { get; set; }

        [CustomValidFields(ValidFields.ValidaModeloCor)]
        public virtual Modelo Modelo { get; set; }

        [CustomValidFields(ValidFields.ValidaPlaca)]
        public string Placa { get; set; }

        //[CustomValidFields(ValidFields.ValidaPlaca)]
        //[Required(ErrorMessage ="O campo TipoVeiculo não pode ser nulo.")]
        public virtual TipoVeiculo TipoVeiculo { get; set; }

        //[Required(ErrorMessage = "O campo Periodo não pode ser nulo.")]
        public virtual Periodo Periodo { get; set; }    
        
        public virtual TipoCor Cor { get; set; }
        //[Required(ErrorMessage = "O campo Colaborador não pode ser nulo.")]

        [CustomValidFields(ValidFields.ValidaColaborador)]
        public virtual Colaborador Colaborador { get; set; }
        //[Required(ErrorMessage = "O campo Periodo não pode ser nulo.")]

        [CustomValidFields(ValidFields.ValidaTermo)]
        public virtual TermoLocacao TermoLocacao { get; set; }

        public bool AceiteTermo { get; set; }

        public StatusLocacao Status { get; set; } = StatusLocacao.EmAprovacao;

    }
}