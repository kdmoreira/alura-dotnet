using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ArrayExtensoes
    {
        public static T[] Concatenar<T>(this T[] a, T[] b)
        {
            var resultado = new T[a.Length + b.Length];

            for (int i = 0; i < a.Length; i++)
            {
                resultado[i] = a[i];
            }

            for (int i = 0; i < b.Length; i++)
            {
                resultado[a.Length + i] = b[i];
            }

            return resultado;
        }

        public static void PrintaArray<T>(this T[] array)
        {
            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}
