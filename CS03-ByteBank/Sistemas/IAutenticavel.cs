using CS03_ByteBank.Domain.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS03_ByteBank.Domain.Sistemas
{
    public interface IAutenticavel
    {
        bool Autenticar(string senha);
    }
}
