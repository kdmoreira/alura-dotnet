using System;

namespace CS01_Algoritmos
{
    class Program
    {
        static void Main(string[] args)
        {
            // CSharp-01: primeiros passos
            
            // P001 Tabuada do 1 ao 10
            Tabuada();

            // P002 Múltiplos de 3, até 100 (for)
            MultiplosDeTresFor();

            // P003 Multiplos de 3, até 100 (while)
            MultiplosDeTresWhile();

            // P004 Fatorial 1 a 10 (while)
            FatorialWhile();

            // P005 Fatorial 1 a 10 (for)
            FatorialFor();

            // P006 Fatorial 1 a 10 (recursivo)
            int fat;
            for (int n = 1; n <= 10; n++)
            {
                fat = FatorialRecursivo(n);
                Console.WriteLine(fat);
            }
        }

        static void Tabuada()
        {
            for (int multiplicador = 1; multiplicador <= 10; multiplicador++)
            {
                for (int multiplicando = 1; multiplicando <= 10; multiplicando++)
                {
                    Console.WriteLine(multiplicando + " * " + multiplicador + " = " + multiplicando * multiplicador);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void MultiplosDeTresFor()
        {
            for (int numero = 1; numero <= 100; numero++)
            {
                if (numero % 3 == 0)
                {
                    Console.WriteLine(numero);
                }
            }
            Console.WriteLine();
        }

        static void MultiplosDeTresWhile()
        {
            int numero = 3;
            while (numero <= 100)
            {
                Console.WriteLine(numero);
                numero += 3;
            }
            Console.WriteLine();
        }

        static void FatorialWhile()
        {
            int fat = 1;
            int n = 1;
            while (n <= 10)
            {
                fat *= n;
                n++;
                Console.WriteLine(fat);
            }
            Console.WriteLine();
        }

        static void FatorialFor()
        {
            int fat = 1;
            for (int n = 1; n <= 10; n++)
            {
                fat *= n;
                Console.WriteLine(fat);
            }
            Console.WriteLine();
        }

        static int FatorialRecursivo(int n)
        {
            if (n == 1)
            {
                return n;
            }
            return n * FatorialRecursivo(n - 1);
        }
    }
}
