using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExercicioFinalWebApi.Models
{
    public class Cliente : UserControls
    {
        [Key]
        public int Id { get; set; }

        [CustomValidFields(Enums.ValidFields.ValidaNomeCompleto)]
        public string NomeCompleto { get; set; }

        [CustomValidFields(Enums.ValidFields.ValidaEstadoCivil)]
        public string EstadoCivil { get; set; }

        [CustomValidFields(Enums.ValidFields.ValidaIdentidade)]
        public string Identidade { get; set; }

        //[MaxLength(15, ErrorMessage = "O CPF possui no máximo 15 caracteres contando . e -.")]
        //[MinLength(11, ErrorMessage = "O CPF possui no minimo 11 caracteres.")]
        [CustomValidFields(Enums.ValidFields.ValidaCpfCnpj)]
        public string Cpf { get; set; }

        //[MaxLength(18,ErrorMessage = "O CNPJ possui no máximo 18 caracteres contando . e -.")]
        //[MinLength(14, ErrorMessage = "O CNPJ possui no minimo 14 caracteres.")]
        [CustomValidFields(Enums.ValidFields.ValidaCnpj)]
        public string Cnpj { get; set; }
        
        public string NomeFantasia { get; set; }

        [MaxLength(9, ErrorMessage = "O CEP possui no máximo 9 caracteres contando o -")]
        [MinLength(8, ErrorMessage = "O CEP possui no minimo 8 caracteres.")]
        [CustomValidFields(Enums.ValidFields.ValidaCep)]
        public string Cep { get; set; }
       
        public string Endereco { get; set; }
       
        public string Cidade { get; set; }
        
        [MaxLength(2, ErrorMessage = "O Estado pode receber 2 caracteres.")]
        [MinLength(2, ErrorMessage = "O Estado pode receber 2 caracteres.")]
        public string Estado { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        [CustomValidFields(Enums.ValidFields.ValidaEmail)]
        public string Email { get; set; }
    }
}