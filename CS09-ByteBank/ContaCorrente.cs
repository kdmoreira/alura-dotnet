using System;
using System.Collections.Generic;
using System.Text;

namespace CS09_ByteBank
{
    /// <summary>
    /// Define uma conta corrente do banco ByteBank.
    /// </summary>
    public class ContaCorrente : IComparable
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma instância de ContaCorrente com os argumentos utilizados;
        /// </summary>
        /// <param name="agencia">Representa o valor da proprieddae <see cref="Agencia"/> e deve possuir um valor maior que zero.</param>
        /// <param name="numero">Representa o valor da proprieddae <see cref="Numero"/> e deve possuir um valor maior que zero.</param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propriedade <see cref="Saldo"></see>
        /// </summary>
        /// <exception cref="ArgumentException">Exeção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/></exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/>.</exception>
        /// <param name="valor">Representa o valor do saque, deve ser maior que 0 e menor que <see cref="Saldo"/>.</param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new ArgumentException();
            }

            _saldo -= valor;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (ArgumentException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new ArgumentException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }

        public override bool Equals(object obj)
        {
            ContaCorrente outraConta = obj as ContaCorrente;

            if (outraConta == null)
            {
                return false;
            }
            return this.Numero == outraConta.Numero &&
                this.Agencia == outraConta.Agencia;
        }

        public override string ToString()
        {
            return $"Agência: {Agencia} Número: {Numero}";
        }

        public int CompareTo(object obj)
        {
            var outraConta = obj as ContaCorrente;

            if (Numero < outraConta.Numero)
            {
                return -1;
            }

            if (Numero == outraConta.Numero)
            {
                return 0;
            }

            return 1;
        }
    }
}
