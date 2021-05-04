using System;
using System.Collections.Generic;
using System.Linq;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Usando a classe List, em vez da classe Lista implementada
            List<int> inteiros = new List<int>();

            inteiros.Add(1);
            inteiros.Add(2);
            inteiros.Add(3);
            inteiros.Remove(3);
            Console.WriteLine(inteiros.Count);
            inteiros.AddRange(new int[] { 4, 5, 6 });

            // Criando uma extensão para List
            ListExtensoes.AdicionarVarios(inteiros, 1, 5687, 1987, 1567, 987);

            // Utilizando a extensão com a classe List estendida
            inteiros.AdicionarVarios(67, 45, 90);

            Console.WriteLine("Printando lista de inteiros: ");
            inteiros.PrintaList();

            // Testando método de extensão (de string, veja na classe) com argumento genérico
            string nome = "karina";
            nome.TesteGenerico<int>();
            nome.TesteGenerico<string>();

            int[] a = new int[] { 0, 1, 2 };
            int[] b = new int[] { 3, 4, 5 };

            Console.WriteLine("Printando arrays concatenadas: ");
            int[] resultado = a.Concatenar(b);
            resultado.PrintaArray();

            // Usando o tipo "var", o compilador entende que queremos armazenar o
            // nome do tipo que temos na expressão de atribuição, isto se chama
            // "Inferência de Tipo de Variável"
            var conta = new ContaCorrente(344, 56456556);
            var contas = new List<ContaCorrente>();
            conta.Depositar(3443);

            //var idade; // Erro: "Variáveis de tipo implícito devem ser inicializadas"


            object outraConta = new ContaCorrente(344, 56456556);
            // Abaixo, não é permitido pois em object caberia uma referência a
            // qualquer classe, que não necessariamente teria o método Depositar
            //outraConta.Depositar(3443);

            var numeros = SomarVarios(1, 2, 3);
            Console.WriteLine("Somar vários: " + numeros);

            // Ordenação
            inteiros.Sort();

            Console.WriteLine("Printando lista ordenada de inteiros: ");
            inteiros.PrintaList();

            var nomes = new List<string>()
            {
                "Wellington",
                "Joana",
                "Bruna",
                "Ana"
            };

            nomes.Sort();
            Console.WriteLine("Printando lista ordenada de nomes: ");
            nomes.PrintaList();

            var novasContas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 57480),
                new ContaCorrente(342, 45678),
                new ContaCorrente(340, 48950),
                new ContaCorrente(290, 18950)
            };

            // Chama a implementação dada em IComparable:
            //novasContas.Sort(); // Lançaria uma InvalidOperationException
            // se não tivéssemos implementado a interface IComparable

            // Utilizando o comparador:
            //contas.Sort(new ComparadorContaCorrentePorAgencia());
            //novasContas.PrintaList();

            // Utilizando expressões lambda:
            IOrderedEnumerable<ContaCorrente> contasOrdenadas =
                novasContas.OrderBy(conta => conta.Numero);

            foreach (var item in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {item.Numero}, ag. {item.Agencia}");
            }

            // Para se precaver contra objetos nulos, é possível expandir a expressão:

            //IOrderedEnumerable<ContaCorrente> contasOrdenadas =
            //    novasContas.OrderBy(conta => { 
            //        if (conta == null)
            //        {
            //            return int.MaxValue; // Deixa no final, MinValue deixaria no começo
            //        }
            //        return conta.Numero;
            //    });

            // Exemplo com tipo sem propriedades
            var meses = new List<string>() { "janeiro", "fevereiro", "março", "abril", "maio", "junho", "julho", "agosto", "setembro", "outubro", "novembro", "dezembro" };
            meses.OrderBy(mes => mes);

            // Where (retorna um IEnumerable<T>):
            var maisContas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 66480),
                null,
                new ContaCorrente(340, 11111),
                null
            };

            Console.WriteLine("Filtra contas não nulas e ordena por nº de agência: ");
            var contasNaoNulas = maisContas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Agencia);

            foreach (var item in contasNaoNulas)
            {
                Console.WriteLine($"Conta número {item.Numero}, ag. {item.Agencia}");
            }
        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        public void MostrarContas(List<ContaCorrente> contas, double saldoMinimo)
        {
            var contasFiltradas = contas.Where(c => c.Saldo >= saldoMinimo);
            foreach (var conta in contasFiltradas)
            {
                Console.WriteLine($"{conta.Numero}/{conta.Agencia}");
            }
        }
    }
}
