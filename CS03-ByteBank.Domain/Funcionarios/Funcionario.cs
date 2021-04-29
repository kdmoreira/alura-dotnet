using System;
using System.Collections.Generic;
using System.Text;

namespace CS03_ByteBank.Domain.Funcionarios
{
    public abstract class Funcionario
    {
        public string Nome { get; set; }
        public string Cpf { get; private set; }
        public double Salario { get; protected set; }
        
        public static int TotalFuncionarios { get; private set; }

        public Funcionario(double salario, string cpf)
        {
            Cpf = cpf;
            Salario = Salario;
            TotalFuncionarios++;
        }

        public abstract void AumentarSalario();

        public abstract double GetBonificacao();
    }
}
