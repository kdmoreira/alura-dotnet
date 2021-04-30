using System;

namespace CS04_Excecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Metodo();
            }
            catch (NullReferenceException ex) // Possível utilizar mais de um catch
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            catch (DivideByZeroException e) // Convenção usar ex ou e
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exception e) // Tipos menos derivados por último
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        public static int Dividir(int numero, int divisor)
        {
            try
            {
                Cliente cliente = null;
                Console.WriteLine(cliente.Cpf);
                return numero / divisor;
            }
            catch (Exception)
            {
                Console.WriteLine("Exceção com número = " + numero + " e divisor = " + divisor);
                throw; // No lugar de return (seria obrigatório) usar throw, que relança a exceção
            }
        }

        static void Metodo()
        {
            TestaDivisao(0);
        }

        static void TestaDivisao(int divisor)
        {
            Dividir(10, divisor);
        }
    }
}
