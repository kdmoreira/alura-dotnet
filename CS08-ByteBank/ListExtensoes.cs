using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia
{
    public static class ListExtensoes
    {
        // A palavra this antes do tipo de argumento do método define que este
        // será um método de extensão: o primeiro argumento é a classe que será
        // estendida
        public static void AdicionarVarios(this List<int> listaDeInteiros, params int[] itens)
        {
            foreach (int item in itens)
            {
                listaDeInteiros.Add(item);
            }
        }
    }
}
