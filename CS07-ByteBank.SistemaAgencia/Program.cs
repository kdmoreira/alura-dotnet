using ByteBank.Modelos;
using CS07_ByteBank.Modelos;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sintaxe de arrays:
            // TIPO[] minhaReferenciaDeArray = new TIPO[numero_de_posicoes];

            // Arrays facilitam iterar por itens do mesmo tipo
            int[] idades = new int[5];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            idades[3] = 50;
            idades[4] = 28;

            int acumulador = 0;
            for (int i = 0; i < idades.Length; i++)
            {
                acumulador += idades[i];
            }
            Console.WriteLine($"A média de idades é {acumulador/idades.Length}");

            // Criando array de contas correntes, o tamanho deve ser informado sempre
            ContaCorrente[] contas = new ContaCorrente[5];

            contas[0] = new ContaCorrente(454, 56556);
            contas[1] = new ContaCorrente(676, 95732);
            contas[2] = new ContaCorrente(900, 12357);

            // Esta característica de informar tamanho pode prejudicar quando
            // um dos índices tenta ser acessado, causando NullReferenceException
            for (int indice = 0; indice < contas.Length; indice++)
            {
                ContaCorrente contaAtual = contas[indice];
                // Aqui cairia na exceção
                //Console.WriteLine($"Conta {indice} {contaAtual.Numero}");
            }

            //Uma alternativa é usar o recurso de inicialização de arrays
            ContaCorrente[] contas2 = new ContaCorrente[]
            {
                new ContaCorrente(455, 56400),
                new ContaCorrente(565, 68900),
                new ContaCorrente(900, 12357),
            };

            // Adicionando e removendo contas de uma ListaContaCorrente
            TesteAdicionarERemover();

            ListaContaCorrente listaContas = new ListaContaCorrente();
            for (int i = 0; i < 3; i++)
            {
                listaContas.Adicionar(new ContaCorrente(120 + i, 120 + i));
            }

            // Acessando ListaContaCorrente com índice após inclusão de um indexador na classe
            ContaCorrente conta1 = listaContas[0];
            Console.WriteLine(conta1);

            // Método para retornar conta corrente
            ContaCorrente conta2 = listaContas.GetItemNoIndice(1);
            Console.WriteLine(conta2);

            // Testando params
            TesteParams();

        }

        static void TesteAdicionarERemover()
        {
            // Adicionando várias contas à nova classe ListaContaCorrente
            ListaContaCorrente listaContas = new ListaContaCorrente();
            for (int i = 0; i < 3; i++)
            {
                listaContas.Adicionar(new ContaCorrente(120 + i, 120 + i));
            }
            ContaCorrente contaParaRemover = new ContaCorrente(999, 99999);
            listaContas.Adicionar(contaParaRemover);

            // Visualizando o conteúdo da ListaContaCorrente
            listaContas.PrintarLista();

            listaContas.Remover(contaParaRemover);

            Console.WriteLine("Após remoção: ");
            listaContas.PrintarLista();

            ContaCorrente contaNaoInclusa = new ContaCorrente(567, 8900);
            listaContas.Remover(contaNaoInclusa);
        }

        static void TesteParams()
        {
            // Passando array como parâmetro
            ContaCorrente[] arrayCC = new ContaCorrente[]
            {
                new ContaCorrente(123, 456),
                new ContaCorrente(789, 101),
                new ContaCorrente(345, 678)
            };

            ListaContaCorrente novaLista = new ListaContaCorrente();
            // Utilizando um novo método
            novaLista.AdicionarVarios(arrayCC);

            novaLista.PrintarLista();

            // Agora, utilizando um outro método com sobrecarga, utilizando params
            novaLista.AdicionarVarios(new ContaCorrente(1, 1), new ContaCorrente(2, 2), new ContaCorrente(3, 3));
            
        }
    }
}
