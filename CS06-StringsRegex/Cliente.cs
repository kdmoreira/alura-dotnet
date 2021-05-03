using System;
using System.Collections.Generic;
using System.Text;

namespace CS06_StringsRegex
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public override bool Equals(object obj)
        {
            // Se obj não for Cliente, o casting abaixo lançará exceção
            //Cliente outroCliente = (Cliente)obj;
            // Casting que não lança exceção caso o obj não seja do tipo Cliente
            Cliente outroCliente = obj as Cliente;

            if (outroCliente == null)
            {
                return false;
            }

            return
                //Nome == outroCliente.Nome &&
                CPF == outroCliente.CPF; // Cpf é o identificador, só ele já basta
                //&& Profissao == outroCliente.Profissao;
        }
    }
}
