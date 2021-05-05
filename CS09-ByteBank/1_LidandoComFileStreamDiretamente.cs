using System;
using System.IO;
using System.Text;

namespace CS09_ByteBank
{
    partial class Program
    {

        static void LidandoComFileStreamDiretamente()
        {
            var enderecoDoArquivo = "contas.txt";
            //var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open);
            //var buffer = new byte[1024]; // 1kb
            //var numeroDeBytesLidos = -1;

            //while (numeroDeBytesLidos != 0)
            //{
            //    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
            //    EscreverBuffer(buffer);
            //}

            ////Usar o buffer desde o índice 0 até o 1024
            //fluxoDoArquivo.Read(buffer, 0, 1024);
            //EscreverBuffer(buffer);

            //fluxoDoArquivo.Close();

            // Com using, temos um try e finally por baixo dos panos, bem como a chamada do método
            // Dispose no caso de o fluxo ser nulo, que internamente chamará o método Close()
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var buffer = new byte[1024]; // 1 kb
                var numeroDeBytesLidos = -1;

                while (numeroDeBytesLidos != 0)
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

                    if (numeroDeBytesLidos == 0)
                    {
                        EscreverBuffer(buffer, numeroDeBytesLidos);
                    }
                }
            }
        }

        static void TesteBuffer()
        {
            var fs = new FileStream("contas.txt", FileMode.Open);

            var buffer = new byte[1024];
            var encoding = Encoding.ASCII;

            var bytesLidos = fs.Read(buffer, 0, 1024);
            var conteudoArquivo = encoding.GetString(buffer, 0, bytesLidos);


            Console.Write(conteudoArquivo);
        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            //var utf8 = new UTF8Encoding();
            var utf8 = Encoding.Default;
            var texto = utf8.GetString(buffer, 0, bytesLidos);
            Console.Write(texto);

            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }
    }
}