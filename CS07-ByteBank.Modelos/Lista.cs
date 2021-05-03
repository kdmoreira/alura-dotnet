﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CS07_ByteBank.Modelos
{
    public class Lista<T>
    {
        private T[] _itens;
        private int _proximaPosicao;
        private int Tamanho { get { return _proximaPosicao; } }

        public Lista(int capacidadeInicial = 5)
        {
            _itens = new T[capacidadeInicial];
            _proximaPosicao = 0;
        }

        public void Adicionar(T item)
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

            T[] novoArray = new T[novoTamanho];

            for (int indice = 0; indice < _itens.Length; indice++)
            {
                novoArray[indice] = _itens[indice];
            }

            _itens = novoArray;
        }

        public void Remover(T item)
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
            // Não é necessário o trecho abaixo, já que a lista pode ser de
            // tipos de valor e não de referência, ou seja, não poderiam ser null
            // e essa impossibilidade já se daria no momento de tentar fazer uma
            // atribuição null a algum item da lista
            //_itens[_proximaPosicao] = null;
            Console.WriteLine("Item removido!");
        }

        public void PrintarLista()
        {
            for (int i = 0; i < _proximaPosicao; i++)
            {
                Console.WriteLine(_itens[i]);
            }
        }

        public T GetItemNoIndice(int indice)
        {
            if (indice < 0 || indice > Tamanho)
            {
                throw new ArgumentOutOfRangeException(nameof(indice));
            }
            return _itens[indice];
        }

        // Este é um indexador, possibilita acessar um obj ListaContaCorrente com índices
        public T this[int indice]
        {
            get { return GetItemNoIndice(indice); }
        }

        //public void AdicionarVarios(ContaCorrente[] contas)
        //{
        //    // Utilizando foreach, construção mais simples
        //    foreach (ContaCorrente conta in contas)
        //        Adicionar(conta);
        //}

        public void AdicionarVarios(params T[] contas)
        {
            // Utilizando foreach, construção mais simples
            foreach (T conta in contas)
                Adicionar(conta);
        }
    }
}
