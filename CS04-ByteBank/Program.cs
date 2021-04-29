using CS02_ByteBank.Domain;
using System;

namespace CS02_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            // Composição de classes
            Cliente gabriela = new Cliente(); // Sem construtor definido
            gabriela.Nome = "Gabriela";
            gabriela.Profissao = "Desenvolvedora C#";
            gabriela.Cpf = "01848769822";

            Cliente bruno = new Cliente();
            bruno.Nome = "Bruno";
            bruno.Profissao = "Desenvolvedor Java";
            bruno.Cpf = "12865478941";

            ContaCorrente contaGabriela = new ContaCorrente(867, 487965); // Com construtor
            contaGabriela.Titular = gabriela;
            contaGabriela.Saldo = 200;
            Console.WriteLine(contaGabriela.Saldo);

            contaGabriela.Depositar(100);
            Console.WriteLine(contaGabriela.Saldo);

            ContaCorrente contaBruno = new ContaCorrente(968, 431625);
            contaBruno.Titular = bruno;
            contaBruno.Saldo = 50;

            contaGabriela.ExibirSaldo();
            contaBruno.ExibirSaldo();

            // Métodos com e sem retorno
            bool resultado1 = contaGabriela.Sacar(500);
            Console.WriteLine("Resultado: " + resultado1);

            bool resultado2 = contaGabriela.Sacar(50);
            Console.WriteLine("Resultado: " + resultado2);

            contaGabriela.ExibirSaldo();

            contaGabriela.Depositar(500);
            contaGabriela.ExibirSaldo();

            bool resultadoTransferencia = contaGabriela.Transferir(contaBruno, 200);
            Console.WriteLine("Resultado Transferência: " + resultadoTransferencia);

            contaGabriela.ExibirSaldo();
            contaBruno.ExibirSaldo();

            // Tentando acessar campo de refêrencia nula
            ContaCorrente contaSemTitular = new ContaCorrente(741, 963258)
            {
                Saldo = 100
            };

            Console.WriteLine(contaSemTitular.Titular); // Titular é null, ok

            try
            {
                Console.WriteLine(contaSemTitular.Titular.Nome); // Exceção
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Ops! A referência do campo titular é nula!");
            }

            // Propriedade da classe, e não de objetos
            Console.WriteLine(ContaCorrente.TotalContasCriadas);
        }
    }
}
