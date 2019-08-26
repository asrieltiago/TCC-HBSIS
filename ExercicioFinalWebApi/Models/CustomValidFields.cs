using ExercicioFinalWebApi.Enums;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using Correios.Net;

namespace ExercicioFinalWebApi.Models
{
    public class CustomValidFields : ValidationAttribute
    {
        ContextDB dB = new ContextDB();

        private ValidFields typeField;

        public CustomValidFields(ValidFields type)
        {
            typeField = type;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                switch (typeField)
                {
                    case ValidFields.ValidaNomeCompleto:
                        return ValidarNome(value, validationContext.DisplayName);

                    case ValidFields.ValidaIdentidade:
                        return ValidarIdentidade(value, validationContext.DisplayName);

                    case ValidFields.ValidaCpfCnpj:
                        {
                            Cliente clientPf = dB.Clientes.FirstOrDefault(x => x.Cpf.ToString() == value.ToString());
                            Cliente clientPj = dB.Clientes.FirstOrDefault(x => x.Cnpj.ToString() == value.ToString());

                            bool pessoaFisica = false;


                            if (clientPf == null)
                            {
                                if (IsValidCpf(value.ToString()))
                                {
                                    pessoaFisica = true;
                                    return ValidationResult.Success;
                                }

                                else
                                {
                                    return new ValidationResult($"O valor informado para o campo {validationContext.DisplayName} não é válido.");
                                }
                            }

                            else if (clientPj == null && pessoaFisica == false)
                            {
                                if (IsValidCnpj(value.ToString()))
                                {
                                    return ValidationResult.Success;
                                }

                                else
                                {
                                    return new ValidationResult($"O valor informado para o campo {validationContext.DisplayName} não é válido.");
                                }
                            }

                            else
                            {
                                return new ValidationResult("O CNPJ / CPF informado já existe.");
                            }
                        }

                    case ValidFields.ValidaCnpj:
                        {
                            Cliente client = dB.Clientes.FirstOrDefault(x => x.Cnpj.ToString() == value.ToString());

                            if (client == null)

                            {
                                if (IsValidCnpj(value.ToString()))
                                {
                                    return ValidationResult.Success;
                                }

                                else
                                {
                                    return new ValidationResult("O valor informado não corresponde à um CNPJ.");
                                }
                            }

                            else
                            {
                                return new ValidationResult("O CPF informado já existe.");
                            }
                        }

                    case ValidFields.ValidaCep:
                        {
                            return ValidarCep(value, validationContext.DisplayName);    
                        }

                    case ValidFields.ValidaCidade:
                        break;

                    case ValidFields.ValidaEstado:
                        break;

                    case ValidFields.ValidaTelefone:
                        return ValidarTelefone(value, validationContext.DisplayName);


                    case ValidFields.ValidaCelular:
                        return ValidarTelefone(value, validationContext.DisplayName);


                    case ValidFields.ValidaEstadoCivil:
                        {
                            Cliente client = dB.Clientes.FirstOrDefault(x => x.EstadoCivil == value.ToString());

                            if (value.ToString() == "Solteiro" || value.ToString() == "Casado" || value.ToString() == "Divorciado" || value.ToString() == "Viúvo")
                            {
                                return ValidationResult.Success;
                            }

                            return new ValidationResult($"O valor informado para o campo {validationContext.DisplayName} é inválido. " +
                                $"Opções disponíveis: Solteiro / Casado / Divorciado / Viúvo.");
                        }


                    case ValidFields.ValidaEmail:
                        {
                            Cliente client = dB.Clientes.FirstOrDefault(x => x.Email == value.ToString());

                            if (client == null)
                            {
                                return ValidarEmail(value, validationContext.DisplayName);

                            }
                            else
                            {
                                return new ValidationResult("O email informado já existe.");
                            }
                        }
                    default:
                        break;
                }
            }

            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório.");
        }



        private ValidationResult ValidarTelefone(object value, string displayField)
        {
            bool result = Regex.IsMatch(value.ToString(), @"(\(?\d{ 2}\)?\s)?(\d{ 4,5}\-\d{ 4})");

            if (result)
                return ValidationResult.Success;

            return new ValidationResult($"o campo {displayField} deve ser no formato XXXXX-XXX");

        }

        private ValidationResult ValidarIdentidade(object value, string displayField)
        {
            //string rg = value.ToString().Replace(".", "").Replace("-", "").Replace(",", "").Replace(" ", "").Trim();
            //
            //int n1 = int.Parse(rg.Substring(0, 1));
            //int n2 = int.Parse(rg.Substring(1, 1));
            //int n3 = int.Parse(rg.Substring(2, 1));
            //int n4 = int.Parse(rg.Substring(3, 1));
            //int n5 = int.Parse(rg.Substring(4, 1));
            //int n6 = int.Parse(rg.Substring(5, 1));
            //int n7 = int.Parse(rg.Substring(6, 1));
            //int n8 = int.Parse(rg.Substring(7, 1));
            //
            //string DV = rg.Substring(8, 1);
            //
            //int Soma = n1 * 2 + n2 * 3 + n3 * 4 + n4 * 5 + n5 * 6 + n6 * 7 + n7 * 8 + n8 * 9;
            //
            //string digitoVerificador = Convert.ToString(Soma % 11);
            //
            //// Se o dígito verificador for igual a 1, automaticamente ele se tornará o algarismo romano X,
            //// pois será feito o cálculo de 11 - o dígito verificador. No caso, ficaria 11 - 1, que é igual a 10.
            //
            //if (digitoVerificador == "1")
            //{
            //    digitoVerificador = "X";
            //}
            //
            //// Se o dígito verificador for igual a 0, automaticamente ele se torna 0, pois 11 - 0 é igual a 11, e
            //// não será permitido isso no dígito verificador, então automaticamente o dígito será 0.
            //else if (digitoVerificador == "0")
            //{
            //    digitoVerificador = "0";
            //}
            //
            //// Se não for nem 0 nem 1, vai ser feito 11 - o dígito verificador. Por exemplo, se o a soma dividida por 11
            //// deu resto 5, será feito 11 - 5, que é igual a 6. Então automaticamente o dígito verificador do RG se tornará o número 6!
            //
            //else
            //{
            //    digitoVerificador = (11 - int.Parse(digitoVerificador)).ToString();
            //}
            //
            //// Verificar se o dígito verificador é igual ao DV do RG que está sendo validado.
            //
            //if (digitoVerificador == DV)
            //{
            //    return ValidationResult.Success;
            //}
            //else
            //{
            //    return new ValidationResult($"o campo {displayField} é inválido.");
            //}


            bool result = Regex.IsMatch(value.ToString(), @"(?=.*\d)[A-Za-z0-9]{4,11}");
            //^(?!(\d)\1{10,})(?=.*\d)[A-Za-z0-9]{11}
            //(?=.*\d)[A-Za-z0-9]{4,11}
            //"^(?!(\d)\1{10,})(?=.*\d)[A-Za-z0-9]{11}


            if (result)
                return ValidationResult.Success;
            
            return new ValidationResult($"o campo {displayField} deve ser no formato XX.XXX.XXX | XX.XXX.XXX-X");

        }

        private ValidationResult ValidarCep(object value, string displayField)
        {            
            bool result = Regex.IsMatch(value.ToString(), @"[0-9]{5}-[0-9]{3}$");

            if (result)
                return ValidationResult.Success;
            return new ValidationResult($"o campo {displayField} deve ser no formato XXXXX-XXX");
        }



        /// <summary>
        /// Método utilizado para validar um email, utilizando-se de um pattern.
        /// </summary>
        /// <param name="value">Campo que verifica se o Email informado é válido</param>
        /// <param name="displayField">Field que está sendo preenchido</param>
        /// <returns></returns>
        private ValidationResult ValidarEmail(object value, string displayField)
        {
            bool result = Regex.IsMatch(value.ToString(), @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            if (result)
                return ValidationResult.Success;

            return new ValidationResult($"O campo {displayField} é inválido.");
        }

        /// <summary>
        /// Método utilizado para validar se o Nome é válido.
        /// </summary>
        /// <param name="value">Nome informado</param>
        /// <param name="displayField">Campo do Nome</param>
        /// <returns></returns>
        private ValidationResult ValidarNome(object value, string displayField)
        {
            bool result = Regex.IsMatch(value.ToString(), @"^[A-Za-zÀ-ú]+ [A-Za-zÀ-ú]+$");

            if (result)
                return ValidationResult.Success;

            return new ValidationResult($"O campo {displayField} é inválido.");
        }

        /// <summary>
        /// Métodos utilizados para validar se os Cpfs e Cnpjs são válidos.
        /// </summary>       
        /// <returns></returns>
        public static bool IsValidCpf(string cpf)
        {
            return IsCpf(cpf);
        }

        /// <summary>
        /// Métodos utilizados para validar se os Cpfs e Cnpjs são válidos.
        /// </summary>       
        /// <returns></returns>
        public static bool IsValidCnpj(string cnpj)
        {
            return IsCnpj(cnpj);
        }

        /// <summary>
        /// Métodos utilizados para validar se os Cpfs e Cnpjs são válidos.
        /// </summary>       
        /// <returns></returns>
        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Métodos utilizados para validar se os Cpfs e Cnpjs são válidos.
        /// </summary>       
        /// <returns></returns>
        private static bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cnpj.EndsWith(digito);
        }

    }
}