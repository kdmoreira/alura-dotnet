using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS03_ByteBank.Domain.Funcionarios
{
    public class Designer : Funcionario
    {
        public Designer(string cpf) : base(3000, cpf)
        {

        }

        public override void AumentarSalario()
        {
            Salario *= 1.15;
        }

        public override double GetBonificacao()
        {
            return Salario * 0.50;
        }
    }
}
