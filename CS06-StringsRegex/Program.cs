using System;
using System.Text.RegularExpressions;

namespace CS06_StringsRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            // Strings são imutáveis:
            // usar métodos sobre strings não altera a original
            string url = "pagina?argumentos";

            // O índice do método Substring é inclusivo
            string argumentos = url.Substring(7);
            Console.WriteLine(argumentos);

            string textoMoeda = "moeda=dolar";
            int indiceMoeda = textoMoeda.IndexOf('=');
            string moeda = textoMoeda.Substring(indiceMoeda + 1);
            Console.WriteLine(moeda);

            // Utilizando classe para extrair argumentos
            string exemploUrl = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            string argumento = "moedaDestino";
            ExtratorValorDeArgumentosURL extrator = 
                new ExtratorValorDeArgumentosURL(exemploUrl);
            
            string valor = extrator.GetValor(argumento);
            Console.WriteLine(valor);

            TesteUpperLower();

            TesteStartsEndsContains();

            TesteRegex();

            // Classe object: todas as classes derivam dela, exemplo:
            object novoExtrator = 
                new ExtratorValorDeArgumentosURL("www.bytebank.com");
            Console.WriteLine(novoExtrator); // Mostra o nome completo da classe

            // Isto se dá porque há o método ToString que é a representação em string da classe
            // trata-se de um método virtual, ou seja, pode ser sobrescrito
            string nomeToString = novoExtrator.ToString();
            Console.WriteLine(nomeToString);

            // Sobrescrevendo o método ToString
            ContaCorrente conta = new ContaCorrente(134, 678);
            Console.WriteLine(conta.ToString());

            // Método Equals:
            CompararObjetos();
        }

        static void TesteUpperLower()
        {
            string texto1 = "PALAVRA";
            string termoBusca = "ra";

            // Reatribuição em termoBusca, pois strings são imutáveis
            //termoBusca = termoBusca.Replace('r', 'R');
            //Console.WriteLine(termoBusca); // Ra

            //termoBusca = termoBusca.Replace('a', 'A');
            //Console.WriteLine(termoBusca); // RA

            // Método mais prático para deixar tudo em caixa-alta:
            Console.WriteLine(termoBusca.ToUpper()); // RA
            // Em caixa-baixa:
            Console.WriteLine(termoBusca.ToLower()); // ra
        }

        static void TesteStartsEndsContains()
        {
            string urlTeste = "https://www.bytebank.com/cambio";
            int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");

            Console.WriteLine(indiceByteBank == 0); // Sinaliza que a url contém a string

            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTeste.EndsWith("cambio"));

            Console.WriteLine(urlTeste.Contains("bytebank"));
        }

        static void TesteRegex()
        {
            // Caracteres são mapeados para seus códigos da tabela ASCII
            // Padrões podem ser [0123456789] ou [0-9] ou [a-z] etc
            string texto = "Olá, meu nome é Fulano e meu número é 091234-9876";

            //string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // Chaves indicando repetição, a vírgula indica que são 4 a 5 caracteres, p. ex.
            //string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // Repare no hífen fora dos colchetes e a interrogação para indicar que é opcional
            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            Regex.IsMatch(texto, padrao); // Retorna True ou False
            Match resultado = Regex.Match(texto, padrao); // Retorna o match
            Console.WriteLine(resultado);
        }

        static void CompararObjetos()
        {
            Cliente carlos_1 = new Cliente();
            carlos_1.Nome = "Carlos";
            carlos_1.CPF = "458.623.120-03";
            carlos_1.Profissao = "Designer";

            Cliente carlos_2 = new Cliente();
            carlos_2.Nome = "Carlos";
            carlos_2.CPF = "458.623.120-03";
            carlos_2.Profissao = "Designer";

            if (carlos_1 == carlos_2)
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais!");
            }

            if (carlos_1.Equals(carlos_2))
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais!");
            }
        }
    }
}
