namespace ContaBancaria
{
    public class Conta
    {
        public int Id { get; set; }

        public string Titular { get; set; }

        public string NumeroConta {  get; set; }

        public EnumTipoConta TipoConta { get; set; }

        public bool Ativo {  get; set; }
    }

    public enum EnumTipoConta
    {
        ContaCorrente = 1,
        Pupança = 2
    }
}
