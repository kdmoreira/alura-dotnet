using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

using ByteBank.Modelos;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(1, 1);

            conta.Sacar(10);

            DateTime dataPagamento = new DateTime(2021, 10, 18);
            Console.WriteLine(dataPagamento);

            DateTime dataCorrente = DateTime.Now;
            Console.WriteLine(dataCorrente);

            TimeSpan diferenca = dataPagamento - dataCorrente;
            Console.WriteLine(diferenca); // Não muito inteligível, para isto, existe o Humanizer

            // Ainda não é o ideal
            Console.WriteLine(GetIntervaloTempoLegivel(diferenca));

            // Após a instalação do pacote NuGet Humanizer
            string mensagem = "Vencimento em " + TimeSpanHumanizeExtensions.Humanize(diferenca);
            Console.WriteLine(mensagem);
        }

        // Poderia adaptar para semanas, meses, mas o Humanizer é uma forma melhor
        static string GetIntervaloTempoLegivel(TimeSpan timeSpan)
        {
            return timeSpan.Days + " dias";
        }
    }
}
