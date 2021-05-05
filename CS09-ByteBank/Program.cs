using System;
using System.IO;
using System.Text;

namespace CS09_ByteBank
{
    // Note o partial, isso serve para que o compilador junte duas classes de mesmo nome
    partial class Program
    {
        static void Main(string[] args)
        {
            //LidandoComFileStreamDiretamente(); // Os métodos estão na classe parcial com este nome

            //TesteBuffer();

            // Uma maneira mais prática de ler aquivos, sem se preocupar com buffers
            // (veja detalhes no primeiro método chamado) e que lê até o final do arquivo
            using (var fluxoDeArquivo = new FileStream("contas.txt", FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    Console.WriteLine(linha);
                }
            }

            using (var fluxoDeArquivo = new FileStream("contas.txt", FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    var msg = $"Conta número {contaCorrente.Numero}, ag. {contaCorrente.Agencia}, Saldo {contaCorrente.Saldo}";
                    Console.WriteLine(msg);
                    //Console.WriteLine(linha);
                }
            }

            // Criando arquivo, salvo em /CS09-ByteBank/bin/Debug/netcoreapp3.1
            //CriarArquivo();

            // Maneira mais prática, sem ter de lidar com bytes
            //CriarArquivoComWriter();

            //TesteCriacaoArquivo();

            //TesteEscritaComFlush();

            //UsarStreamDeEntrada();

            // A forma mais simples, e mais conhecida de trabalhar com entradas:
            Console.WriteLine("Digite o seu nome:");
            var nome = Console.ReadLine(); 

            Console.WriteLine("Aplicação finalizada...");

            // Uma forma simples de ler arquivos externos, mas só deve ser utilizada
            // em arquivos menores, pois lerá o arquivo inteiro de uma vez:
            var linhas = File.ReadAllLines("contas.txt"); // Existe tbm o ReadAllText()
            Console.WriteLine(linhas.Length);
            Console.WriteLine();

            var bytesArquivo = File.ReadAllBytes("contas.txt");
            Console.WriteLine($"Arquivo contas.txt possui{ bytesArquivo.Length} bytes");
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            string[] campos = linha.Split(' '); // Para arquivos CSV, basta trocar por ','

            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace(".", ",");
            var nomeTitular = campos[3];

            var agenciaComInt = int.Parse(agencia);
            var numeroComInt = int.Parse(numero);
            var saldoComoDouble = double.Parse(saldo);

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
            resultado.Depositar(saldoComoDouble);
            resultado.Titular = titular;

            return resultado;
        }

        static void CriarArquivo()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "123,8974,2560.40, Maria Silveira";
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(contaComoString);

                fluxoDeArquivo.Write(bytes, 0, bytes.Length);
            }
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas2.csv";
            // Usando FileMode.CreateNew, pois caso ja exista arquivo com o mesmo nome,
            // ele não será sobrescrito
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write("456,65465,456.0,Pedro");
            }
        }

        static void TesteCriacaoArquivo()
        {
            var arquivoOriginal = new FileStream("teste.txt", FileMode.Open);
            var arquivoNovo = new FileStream("teste_copia.txt", FileMode.Create);
            var buffer = new byte[1024];

            using (arquivoOriginal)
            using (arquivoNovo)
            {
                var bytesLidos = -1;
                while (bytesLidos != 0)
                {
                    bytesLidos = arquivoOriginal.Read(buffer, 0, 1024);
                    arquivoNovo.Write(buffer, 0, bytesLidos);
                }
            }

            var rodape = Encoding.UTF8.GetBytes("Este documento é uma cópia do original");
            arquivoNovo.Write(rodape, 0, rodape.Length);
        }

        static void TesteEscritaComFlush()
        {
            var caminho = "testeflush.txt";

            using (var fluxoDeArquivo = new FileStream(caminho, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < 10; i++)
                {
                    escritor.WriteLine($"Linha {i}");
                    //escritor.Flush(); // Despeja o buffer para o Stream
                    // Isso significa que sem o Flush o arquivo só seria escrito depois de
                    // finalizado o laço

                    Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter para adicionar mais uma!");
                    Console.ReadLine();
                }
            }
        }

        static void EscritaBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs))
            {
                escritor.Write(456); // Número da Agência
                escritor.Write(546544); // Número da conta
                escritor.Write(4000.50); // Saldo
                escritor.Write("Gustavo Braga");
            }
        }

        static void LeituraBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var numeroConta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}");
            }
        }
    }
}
