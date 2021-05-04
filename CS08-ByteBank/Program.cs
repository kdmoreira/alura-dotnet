using System;
using System.Collections.Generic;
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

        }
    }
}
