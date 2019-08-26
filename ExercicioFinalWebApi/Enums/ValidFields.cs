using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioFinalWebApi.Enums
{
    public enum ValidFields
    {
            ValidaNomeCompleto,
            ValidaIdentidade,
            ValidaCpfCnpj,
            ValidaCnpj,
            ValidaCep,
            ValidaCidade,
            ValidaEstado,
            ValidaTelefone,
            ValidaCelular,
            ValidaEmail,
            ValidaEstadoCivil
    }

    public enum ValidEstadoCivil
    {
        Solteiro,
        Casado,
        Viúvo,
        Divorciado
    }
}