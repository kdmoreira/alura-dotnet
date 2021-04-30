using System;

namespace CS02_ByteBank.Domain
{
    public class ContaCorrente
    {
        public Cliente Titular // Quando não há regras para get e set
        {
            get;
            set;
        }
        public int Agencia { get; set; } // Mais legível
        public int Numero { get; set; }

        // Static por ser característica da classe e não dos objetos
        public static int TotalContasCriadas { get; private set; } // Set apenas internamente

        // Exemplo de encapsulamento
        private double _saldo = 100;
        public double Saldo // Definindo um get e set desta forma, por haver regras
        {
            get
            {
                return _saldo;
            }
            set
            {
                // Obs: útil para impedir set de valores menores que 0, mas
                // não impede um valor default 0, para isso, usar um construtor
                if (value < 0)
                {
                    return;
                }
                _saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numero) // Construtor
        {
            Agencia = agencia;
            Numero = numero;
            TotalContasCriadas++;
        }

        public void ExibirSaldo()
        {
            Console.WriteLine("Saldo da conta do(a) " + this.Titular.Nome + " é R$" + this.Saldo);
        }

        public bool Sacar(double valor)
        {
            if (this._saldo < valor)
            {
                return false;
            }
            this._saldo -= valor;
            return true;

        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public bool Transferir(ContaCorrente contaDestino, double valor)
        {
            if (this._saldo < valor)
            {
                return false;
            }
            this._saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}
