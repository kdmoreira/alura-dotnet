using System;
using System.Collections.Generic;

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

        }
    }
}
