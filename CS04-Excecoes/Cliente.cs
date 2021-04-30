using System;
using System.Collections.Generic;
using System.Text;

namespace CS04_Excecoes
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Profissao { get; set; }

        public string _cpf;
        public string Cpf
        {
            get
            {
                return _cpf;
            }
            set
            {
                // Aqui poderia incluir uma validação do CPF
                _cpf = value;
            }
        }
    }
}
