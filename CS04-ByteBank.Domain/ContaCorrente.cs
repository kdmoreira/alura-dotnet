using CS04_ByteBank.Domain.Exceptions;
using System;

namespace CS04_ByteBank.Domain
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }

        private readonly int _numero;
        public int Numero
        {
            get { return _numero; }
        }
        // Obs: um public int Numero { get; } teria o mesmo efeito de criar um
        // campo private readonly _numero que seria retornado no get de Numero,
        // em Agencia será feito desta forma simplificada:
        public int Agencia { get; }

        public static int TotalContasCriadas { get; private set; }
        public static double TaxaOperacao;
        public static int ContadorSaquesNaoPermitidos { get; private set; }
        public static int ContadorTransferenciasNaoPermitidas { get; private set; }

        private double _saldo = 100;
        public double Saldo
        {
            get { return _saldo; }
            set
            {
                if (value < 0)
                {
                    return;
                }
                _saldo = value;
            }
        }

        public ContaCorrente(int agencia, int numero)
        {
            if (agencia <= 0)
                throw new ArgumentException("O número da agência deve ser maior que zero.", nameof(agencia));

            if (numero <= 0)
                throw new ArgumentException("O número da conta deve ser maior que zero.", nameof(numero));

            Agencia = agencia;
            _numero = numero;

            //if (TotalContasCriadas == 0)
            //    throw new Exception("Tentativa de divisão por zero.");

            TotalContasCriadas++;
            // Se o cálculo abaixo viesse antes do incremento, ocorreria uma
            // exeção sem tratamento mesmo com catch na Main: DivisionByZero
            TaxaOperacao = 30 / TotalContasCriadas;
        }

        public void ExibirSaldo()
        {
            Console.WriteLine("Saldo da conta do(a) " + this.Titular.Nome + " é R$" + this.Saldo);
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));

            if (this._saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            this._saldo -= valor;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public void Transferir(ContaCorrente contaDestino, double valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para transferência");

            // No lugar de usar if, utilizar exceções, como abaixo deste bloco comentado
            //if (this._saldo < valor)
            //{
            //    ContadorTransferenciasNaoPermitidas++;
            //    throw new SaldoInsuficienteException("Saldo insuficiente para a transferência");
            //}

            //Sacar(valor);

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                // Abaixo, exemplos que fariam a Stack Trace abandonar o método Sacar,
                // por lançar em um novo objeto:
                //throw ex;
                //throw new SaldoInsuficienteException(Saldo, valor);
                //throw new SaldoInsuficienteException("Operação não realizada.");

                // Alternativas:
                // throw; // Desta forma o método sacar também aparecerá na Stack Trace
                throw new OperacaoFinanceiraException("Operação não realizada.", ex); // Passando a msg e objeto InnerException
            }

            contaDestino.Depositar(valor);
        }
    }
}
