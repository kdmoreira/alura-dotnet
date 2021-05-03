using System;
using System.Collections.Generic;
using System.Text;

namespace CS06_StringsRegex
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;
        public string Url { get; }

        public ExtratorValorDeArgumentosURL(string url)
        {
            //if (url == null)
            //{
            //    throw new ArgumentNullException(nameof(url));
            //}

            //if (url == "")
            //{
            //    throw new ArgumentException("O argumento url não pode ser uma string vazia.", nameof(url));
            //}

            // Abaixo, melhor maneira de fazer isto:
            if (String.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser uma string nula ou vazia.", nameof(url));
            }

            int indiceInterrogacao = url.IndexOf('?');
            _argumentos = url.Substring(indiceInterrogacao + 1);

            Url = url;
        }

        public string GetValor(string nomeParametro)
        {
            // Desta forma pegaria um resultado até o final da string
            //int indice = Url.IndexOf(nomeParametro);
            //int length = nomeParametro.Length;
            //string sub = Url.Substring(length + indice + 1);

            // Normalizar parâmetros e argumentos
            nomeParametro = nomeParametro.ToUpper();
            string argumentosCaixaAlta = _argumentos.ToUpper();

            // Desta forma, é possível pegar o resultado e ignorar o restante da string
            string termo = nomeParametro + "=";
            int indiceTermo = argumentosCaixaAlta.IndexOf(termo);

            string resultado = _argumentos.Substring(indiceTermo + termo.Length);
            int indiceEComercial = resultado.IndexOf('&');

            // Quando o caractere passado para o IndexOf não existe, o método
            // retorna -1
            if (indiceEComercial == -1)
            {
                return resultado;
            }

            // Removendo o restante da string que não faz parte do resultado, ou seja
            // a partir do &
            return resultado.Remove(indiceEComercial);
        }
    }
}
