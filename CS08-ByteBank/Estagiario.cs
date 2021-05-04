using System;

namespace ByteBank.SistemaAgencia
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

        protected internal override double GetBonificacao()
        {
            throw new NotImplementedException();
        }
    }
}
