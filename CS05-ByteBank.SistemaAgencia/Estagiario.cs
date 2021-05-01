using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_02
{
    public class Estagiario : Funcionario
    {
        public Estagiario(double salario, string cpf) : base (salario, cpf)
        {

        }

        public override void AumentarSalario()
        {
            throw new NotImplementedException();
        }

        // Na classe funcionário, este método é internal protected, porém, como
        // Estagiário faz parte de outro projeto, deve ser somente protected, pois
        // não faz sentido que seja internal, ou seja, visível dentro deste projeto também
        protected override double GetBonificacao()
        {
            throw new NotImplementedException();
        }
    }
}
