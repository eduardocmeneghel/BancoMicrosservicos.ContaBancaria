namespace ContaBancaria.DTO
{
    public class InserirContaDTO
    {
        public string Titular { get; set; }

        public string NumeroConta { get; set; }

        public EnumTipoConta TipoConta { get; set; }
    }

    public class EditarContaDTO
    {
        public string Titular { get; set; }

        public EnumTipoConta TipoConta { get; set; }
    }
}
