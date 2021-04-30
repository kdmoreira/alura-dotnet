using CS04_ByteBank.Domain;
using CS04_ByteBank.Domain.Exceptions;
using CS04_ByteBank.Domain.LeitorArquivo;
using System;
using System.IO;

namespace CS04_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CarregarContasComUsing();
            }
            catch (Exception)
            {
                Console.WriteLine("CATCH NO METODO MAIN");
            }
            //CarregarContas();
            //TestaInnerException();
            //TestaExcecoes();
        }

        private static void CarregarContasComUsing()
        {
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt"))
            {
                leitor.LerProximaLinha();
            }
        }

        private static void CarregarContas()
        {
            // Abaixo, uma forma de lidar com exceções usando o finally,
            // o que poderia ter sido simplificado (veja exemplo com using acima)
            LeitorDeArquivo leitor = null;
            try
            {
                leitor = new LeitorDeArquivo("contas.txt");
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
            catch (IOException)
            {
                Console.WriteLine("Exceção do tipo IOException capturada e tratada!");
            }
            finally
            {
                if (leitor != null)
                {
                    leitor.Fechar();
                }
            }
        }

        static void TestaInnerExceptions()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(1, 1);
                ContaCorrente conta2 = new ContaCorrente(2, 2);

                conta.Sacar(500);
                //conta.Transferir(conta2, 500);
            }
            catch (OperacaoFinanceiraException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);

                //Console.WriteLine("Informações da INNER EXCEPTION:" );
                //Console.WriteLine(ex.InnerException.Message);
                //Console.WriteLine(ex.InnerException.StackTrace);
            }
        }

        static void TestaExcecoes()
        {
            try
            {
                ContaCorrente conta = new ContaCorrente(1, 1);
                ContaCorrente conta2 = new ContaCorrente(2, 2);

                // Testando exceções personalizadas
                //conta.Sacar(500);
                //conta.Sacar(-50);
                conta.Transferir(conta2, 500);
                //conta.Transferir(conta2, -500);

                // Esta divisão por zero é tratada e o fluxo segue normalmente
                //var div = 0;
                //var res = 1 / div;
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Ocorreu uma exceção do tipo DivideByZeroException.");
                Console.WriteLine(ex.Message);
            }
            catch (SaldoInsuficienteException ex) // Exceção personalizada
            {
                Console.WriteLine(ex.Saldo);
                Console.WriteLine(ex.ValorSaque);

                Console.WriteLine(ex.StackTrace);

                Console.WriteLine("Exceção do tipo SaldoInsuficienteException.");
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "numero")
                {

                }

                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException.", ex.ParamName);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
