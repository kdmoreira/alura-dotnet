using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        // A palavra this antes do tipo de argumento do método define que este
        // será um método de extensão: o primeiro argumento é a classe que será
        // estendida
        //public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens)
        //{
        //    foreach (int item in itens)
        //    {
        //        listaDeInteiros.Add(item);
        //    }
        //}

        // Criando um método genérico que sirva para qualquer List, sem this e com <T>
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }

        public static void TesteGenerico<T2>(this string texto)
        {

        }

        public static void PrintaList<T>(this List<T> lista)
        {
            foreach (var item in lista)
            {
                Console.WriteLine(item);
            }
        }
    }
}
