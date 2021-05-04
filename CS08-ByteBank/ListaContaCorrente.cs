using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.SistemaAgencia
{
    public class ListaContaCorrente
    {
        private ContaCorrente[] _itens;
        private int _proximaPosicao;
        private int Tamanho { get { return _proximaPosicao; } }

        public ListaContaCorrente(int capacidadeInicial = 5)
        {
            _itens = new ContaCorrente[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(ContaCorrente item)
        {
            VerificaCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++;
        }

        private void VerificaCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
                return;

            int novoTamanho = _itens.Length * 2;
            Console.WriteLine("Capacidade aumentada");

            if (novoTamanho < tamanhoNecessario)
            {
                novoTamanho = tamanhoNecessario;
            }

            ContaCorrente[] novoArray = new ContaCorrente[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }

            _itens = novoArray;
        }

        public void Remover(ContaCorrente item)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                if (item.Equals(_itens[i]))
                {
                    indiceItem = i;
                    break;
                }
            }

            if (indiceItem == -1)
            {
                Console.WriteLine("Item não pertence à array.");
                return;
            }

            for (int j = indiceItem; j < _proximaPosicao - 1; j++)
            {
                _itens[j] = _itens[j + 1];
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
            Console.WriteLine("Item removido!");
        }

        public void PrintarLista()
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                Console.WriteLine($"Ag:{_itens[i].Agencia} n:{_itens[i].Numero}");
            }
        }

        public ContaCorrente GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice > Tamanho)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }

        // Este é um indexador, possibilita acessar um obj ListaContaCorrente com índices
        public ContaCorrente this[int indice]
        {
            get { return GetItemNoIndice(indice); }
        }

        //public void AdicionarVarios(ContaCorrente[] contas)
        //{
        //    // Utilizando foreach, construção mais simples
        //    foreach (ContaCorrente conta in contas)
        //        Adicionar(conta);
        //}

        public void AdicionarVarios(params ContaCorrente[] contas)
        {
            // Utilizando foreach, construção mais simples
            foreach (ContaCorrente conta in contas)
                Adicionar(conta);
        }
    }
}
