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
        ContextDB db = new ContextDB();

        private ValidFields typeField;

        public CustomValidFields(ValidFields type)
        {
            typeField = type;
        }

        //public object ValidaCampos(object value)
        //{
        //    Locacao locacao = new Locacao();
        //
        //    var tipo = db.tipoVeiculos.FirstOrDefault(x => x.Codigo == locacao.TipoVeiculo.Codigo);
        //    var modelo = db.modelos.FirstOrDefault(x => x.Id == locacao.Modelo.Id);
        //    var colaborador = db.colaboradores.FirstOrDefault(x => x.Id == locacao.Colaborador.Id);
        //    var periodo = db.periodos.FirstOrDefault(x => x.Id == locacao.Periodo.Id);
        //    var cor = db.tipoCores.FirstOrDefault(x => x.Id == locacao.Cor.Id);
        //    var termo = db.termoLocacoes.FirstOrDefault(x => x.Id == locacao.TermoLocacao.Id);
        //
        //    //if (tipo == null || modelo == null || colaborador == null || periodo == null || cor == null || termo == null)
        //       // return BadRequest("Existem campos inválidos em branco, favor verificar.");
        //
        //    locacao.TipoVeiculo = tipo;
        //    locacao.Modelo = modelo;
        //    locacao.Colaborador = colaborador;
        //    locacao.Periodo = periodo;
        //    locacao.Cor = cor;
        //    locacao.TermoLocacao = termo;
        //
        //    //if (tipo != null || modelo != null || colaborador != null || periodo != null || cor != null || termo != null)
        //
        //    return value;
        //    
        //}

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Locacao locacao = (Locacao)validationContext.ObjectInstance;

            if (value != null)
            {
                if (locacao.TipoVeiculo.Codigo <= 1)
                {
                    switch (typeField)
                    {
                        case ValidFields.ValidaPlaca:
                            {
                                var placa = locacao.Placa;
                                var repetido = db.locacoes.Any(x => x.Placa.ToString() == placa);
                                var codigo = locacao.TipoVeiculo.Codigo;

                                value = placa;

                                if (repetido == false)
                                {
                                    bool placaPadrao = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[-][0-9]{4}$");
                                    bool placaMercosulAutomovel = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");
                                    bool placaMercosulMoto = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{2}[a-zA-Z]{1}[0-9]{1}$");

                                    if (codigo == 0 && (placaPadrao || placaMercosulAutomovel))
                                        return ValidationResult.Success;

                                    else if (codigo == 1 && (placaPadrao || placaMercosulMoto))
                                        return ValidationResult.Success;

                                    return new ValidationResult($"A Placa informada não está no formato aceitável.");                                    
                                }

                                return new ValidationResult("A placa informada já possui um registro cadastrado.");
                            }

                        case ValidFields.ValidaColaborador:
                            {
                                var colaborador = locacao.Colaborador.Id;
                                var codigo = locacao.TipoVeiculo.Codigo;
                                var repetido = db.locacoes.Any(x => x.Colaborador.Id == colaborador);

                                if (repetido == false)                                
                                    return ValidationResult.Success;
                                                               
                                return new ValidationResult("O Colaborador informado já possui um registro cadastrado.");
                            }

                        case ValidFields.ValidaModeloCor:
                            {
                                var cor = locacao.Cor;
                                var modelo = locacao.Modelo;

                                if (modelo != null && cor != null) 
                                    return ValidationResult.Success;

                                return new ValidationResult("É necessário informar um Modelo e Cor válidas.");
                                //return ValidarModeloCor(value, validationContext.DisplayName);
                            }
                        case ValidFields.ValidaTermo:
                            {
                                if (locacao.AceiteTermo == true)                                
                                    return ValidationResult.Success;                                

                                return new ValidationResult($"Para realizar a locação, você deve aceitar os termos de uso.");
                            }

                        default:
                            break;
                    }
                }
            }            

            if (locacao.Modelo == null || locacao.Placa == null || locacao.Cor == null || locacao.AceiteTermo == true)
            {
                if(locacao.TipoVeiculo.Codigo > 1 && locacao.TipoVeiculo.Codigo < 4)                
                    return ValidationResult.Success;                
            }
        
            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório.");
        }
        //private ValidationResult ValidarPlaca(object value, string displayField)
        //{
        //    Locacao locacao = new Locacao;
        //
        //    var codigo = db.locacoes.FirstOrDefault(x => x.TipoVeiculo.Codigo == (int)value);
        //    var placa = db.locacoes.FirstOrDefault(x => x.Placa == value.ToString());
        //
        //    bool placaPadrao = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[-][0-9]{4}$");
        //    bool placaMercosulAutomovel = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");
        //    bool placaMercosulMoto = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{2}[a-zA-Z]{1}[0-9]{1}$");
        //
        //
        //    if (codigo.TipoVeiculo.Codigo == 0)
        //        //if (placa && placaPadrao || placaMercosulAutomovel)
        //        return ValidationResult.Success;
        //
        //    else if (codigo.TipoVeiculo.Codigo == 1 && placaPadrao || placaMercosulMoto)
        //        return ValidationResult.Success;
        //
        //    return new ValidationResult($"A {displayField} informada não está no formato aceitável.");
        //}

        //private ValidationResult ValidarModeloCor(object value, string displayField)
        //{
        //    var modelo = db.modelos.FirstOrDefault(x => x.Id == (int)value);
        //    var cor = db.tipoCores.FirstOrDefault(x => x.Id == (int)value);
        //
        //    if (cor != null && modelo != null)
        //        return ValidationResult.Success;
        //
        //    return new ValidationResult($"O Campo {displayField} precisa ser preenchido.");
        //}

        //private ValidationResult ValidarTermo(object value, string displayField)
        //{
        //    var termo = db.termoLocacoes.FirstOrDefault(x => x.Id == (int)value);
        //
        //    if (termo.Ativo == true)
        //    {
        //        return ValidationResult.Success;
        //    }
        //
        //    return new ValidationResult($"Para realizar a locação, você deve aceitar os termos de uso.");
        //}

        //private ValidationResult ValidarColaborador(object value, string displayField)
        //{
        //    var colaborador = db.colaboradores.FirstOrDefault(x => x.Id == (int)value);
        //
        //    if (colaborador != null)
        //    {
        //        return ValidationResult.Success;
        //    }
        //    return new ValidationResult($"O Campo {displayField} precisa ser preenchido.");
        //}
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