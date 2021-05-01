using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos.Funcionarios
{
    public abstract class Funcionario
    {
        public static int TotalDeFuncionarios { get; private set; }

        public string Nome { get; set; }

        public string CPF { get; private set; }
        
        public double Salario { get; protected set; }

        public Funcionario(double salario, string cpf)
        {
            Console.WriteLine("Criando FUNCIONARIO");

            CPF = cpf;
            Salario = salario;

            TotalDeFuncionarios++;
        }

        public abstract void AumentarSalario();

        // "internal protected" (é um modificador só) combina as propriedades de:
        // "protected", pois permite que este método seja visível para classes derivadas desta
        // "internal", pois pode ser acessado por classes de dentro do projeto
        // COM O ADICIONAL: pode ser acessado por classes derivadas de outros projetos
        internal protected abstract double GetBonificacao();
        // Nas classes derivadas, dentro DESTE projeto, o método deve estar internal protected também
    }
}
