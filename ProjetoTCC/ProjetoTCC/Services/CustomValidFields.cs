using ProjetoTCC.Enums;
using SistemaLocacaoHBSIS.Enums;
using SistemaLocacaoHBSIS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjetoTCC.Services
{
    public class CustomValidFields : ValidationAttribute
    {
        ContextDB dB = new ContextDB();

        private ValidFields typeField;
        private StatusLocacao statusField;

        public CustomValidFields(StatusLocacao status, ValidFields type)
        {
            typeField = type;
            statusField = status;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var codigo = dB.locacoes.Find().TipoVeiculo.Codigo;

                if (codigo <= 1)
                {
                    switch (typeField)
                    {
                        case ValidFields.ValidaPlaca:
                            {
                                return ValidarPlaca(value, validationContext.DisplayName);
                            }

                        case ValidFields.ValidaModeloCor:
                            {
                                return ValidarModeloCor(value, validationContext.DisplayName);
                            }
                        case ValidFields.ValidaTermo:
                        {
                                return ValidarTermo(value, validationContext.DisplayName);
                        }


                        default:
                            break;
                    }
                }

                //{
                //if (locacao.Placa != null && locacao.Modelo != null && locacao.Cor != null)
                //{

                //}
                //}
            }
            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório.");
        }
        private ValidationResult ValidarPlaca(object value, string displayField)
        {
            var codigo = dB.locacoes.Find().TipoVeiculo.Codigo;

            bool placaPadrao = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[-][0-9]{4}$");
            bool placaMercosulAutomovel = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");
            bool placaMercosulMoto = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{2}[a-zA-Z]{1}[0-9]{1}$");

            if (codigo == 0 && placaPadrao || placaMercosulAutomovel)
                return ValidationResult.Success;

            else if (codigo == 1 && placaPadrao || placaMercosulMoto)
                return ValidationResult.Success;

            return new ValidationResult($"A Placa informada é inválida para o Tipo de Veículo informado.");
        }

        private ValidationResult ValidarModeloCor(object value, string displayField)
        {
            var modelo = dB.locacoes.Find().Modelo;
            var cor = dB.locacoes.Find().Cor;

            if (cor != null && modelo != null)
                return ValidationResult.Success;

            return new ValidationResult($"O Campo {displayField} precisa ser preenchido.");
        }

        private ValidationResult ValidarTermo(object value, string displayField)
        {
            var termo = dB.locacoes.Find().AceiteTermo;

            if(termo == true)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"O Termo de Uso precisa ser aceito para continuar.");
        }
    }
}




//[ResponseType(typeof(Locacao))]
//[AcceptVerbs("PATCH")]
//[Route("api/Locacoes/{codLocacao}/{idStatus}")]
//public IHttpActionResult AprovaLocacao(int codLocacao, int idStatus)
//{
//    Locacao locacao = db.Locacoes.Find(codLocacao);
//    if (locacao == null)
//    {
//        return NotFound();
//    }
//    switch (idStatus)
//    {
//        case 1: locacao.Situacao = Status.VINGENTE; break;
//        case 3: locacao.Situacao = Status.FILA_DE_ESPERA; break;
//    };
//
//    // locacao.Situacao = Status.FILA_DE_ESPERA;
//
//    db.SaveChanges();
//
//    return Ok(locacao);
//}