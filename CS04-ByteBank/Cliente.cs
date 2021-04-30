namespace CS04_ByteBank.Domain
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Profissao { get; set; }

        public string _cpf;
        public string Cpf
        {
            get
            {
                return _cpf;
            }
            set
            {
                // Aqui poderia incluir uma validação do CPF
                _cpf = value;
            }
        }
    }
}
