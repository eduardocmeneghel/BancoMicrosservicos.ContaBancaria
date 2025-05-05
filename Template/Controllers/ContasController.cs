using ContaBancaria.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Servicos;

namespace ContaBancaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly ContaDomain _contaDomain;

        public ContasController()
        {
            _contaDomain = new ContaDomain();
        }

        [HttpPost]
        public IActionResult Inserir(InserirContaDTO dadosDaInsercao)
        {
            try
            {
                _contaDomain.Inserir(dadosDaInsercao);

                return Ok("Conta inserida com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Alterar([FromRoute] int id, [FromBody] EditarContaDTO dadosDaAlteracao)
        {
            try
            {
                _contaDomain.Alterar(id, dadosDaAlteracao);

                return Ok("Conta alterada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet]
        public IActionResult BuscarContas()
        {
            try
            {
                var contas = _contaDomain.BuscarContas();

                return Ok(contas);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("/api/[controller]/{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                var contas = _contaDomain.BuscarPorId(id);

                return Ok(contas);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("/api/[Controller]/Inativar{id}")]
        public IActionResult Inativar([FromRoute] int id)
        {
            try
            {
                _contaDomain.Inativar(id);

                return Ok("Conta inativada com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
