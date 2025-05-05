using ContaBancaria;
using ContaBancaria.DTO;
using Exemplo;
using Template.Infra;

namespace Servicos
{
    public class ContaDomain
    {
        public DataContext _dataContext;

        public ContaDomain()
        {
            _dataContext = GeradorDeServicos.CarregarContexto();
        }

        public void Inserir(InserirContaDTO dadosDaInsercao)
        {
            var conta = new Conta();

            conta.Titular = dadosDaInsercao.Titular;
            conta.TipoConta = dadosDaInsercao.TipoConta;
            conta.NumeroConta = dadosDaInsercao.NumeroConta;
            conta.Ativo = true;

            if (conta.NumeroConta == "") 
            {
                throw new Exception("Falta informar o número da conta");
            }

            _dataContext.Add(conta);

            _dataContext.SaveChanges();
        }

        public void Alterar(int id, EditarContaDTO dadosAlteracao)
        {
            var conta = _dataContext.Contas.FirstOrDefault(p => p.Id == id);

            conta.Titular = dadosAlteracao.Titular;
            conta.TipoConta = dadosAlteracao.TipoConta;

            _dataContext.SaveChanges();
        }

        public List<Conta> BuscarContas()
        {
            var listaConta = _dataContext.Contas.ToList();

            return listaConta;
        }

        public Conta BuscarPorId(int id)
        {
            var conta = _dataContext.Contas.First(p => p.Id == id);

            return conta;
        }

        public void Inativar(int id)
        {
            var conta = _dataContext.Contas.FirstOrDefault(p => p.Id == id);

            conta.Ativo = false;

            _dataContext.SaveChanges();
        }
    }
}
