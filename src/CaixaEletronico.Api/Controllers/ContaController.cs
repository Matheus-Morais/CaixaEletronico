using CaixaEletronico.Api.Models;
using CaixaEletronico.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CaixaEletronico.Api.Controllers;

[ApiController]
[Route("v1/conta")]
public class ContaController : Controller
{
    private readonly IConta _conta;

    public ContaController(IConta conta)
    {
        _conta = conta;
    }

    [HttpPost("depositar")]
    public IActionResult Depositar([FromBody] ValorViewModel model)
    {
        _conta.Deposito(model.Valor);
        return Ok(_conta.Saldo);
    }

    [HttpPost("sacar")]
    public IActionResult Sacar([FromBody] ValorViewModel model)
    {
        _conta.Saque(model.Valor);
        return Ok(_conta.Saldo);
    }

    [HttpGet("extrato")]
    public IActionResult Extrato()
    {
        return Ok(_conta.Extrato);
    }

    [HttpGet("saldo")]
    public IActionResult Saldo()
    {
        return Ok($"Saldo: {_conta.Saldo}");
    }
}
