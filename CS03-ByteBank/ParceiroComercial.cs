using CS03_ByteBank.Domain.Sistemas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS03_ByteBank.Domain
{
    public class ParceiroComercial : IAutenticavel
    {
        public string Senha { get; set; }

        public bool Autenticar(string senha)
        {
            return Senha == Senha;
        }
    }
}
