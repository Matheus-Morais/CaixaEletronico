using CaixaEletronico.Api.Models;
using CaixaEletronico.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CaixaEletronico.Api.Controllers;

[ApiController]
[Route("v1/conta")]
public class ContaController : Controller
{
    private Conta conta;

    public ContaController()
    {
        conta = new Conta();
    }

    [HttpPost("depositar")]
    public IActionResult Depositar([FromBody] ValorViewModel model)
    {
        conta.Deposito(model.Valor);
        return Ok(conta.Saldo);
    }

    [HttpPost("sacar")]
    public IActionResult Sacar([FromBody] ValorViewModel model)
    {
        conta.Saque(model.Valor);
        return Ok(conta.Saldo);
    }

    [HttpGet("extrato")]
    public IActionResult Extrato()
    {
        return Ok(conta.Extrato);
    }

    [HttpGet("saldo")]
    public IActionResult Saldo()
    {
        return Ok($"Saldo: {conta.Saldo}");
    }
}
