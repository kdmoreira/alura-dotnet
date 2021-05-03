using System;
using System.Collections.Generic;
using System.Text;

namespace ByteBank.Modelos
{
    // Uma classe internal só pode ser utilizada no project onde reside, é o
    // mesmo que omitir o modificador de acesso com "class AutenticacaoHelper"
    internal class AutenticacaoHelper
    {
        public bool CompararSenhas(string senhaVerdadeira, string senhaTentativa)
        {
            return senhaVerdadeira == senhaTentativa;
        }
    }
}
