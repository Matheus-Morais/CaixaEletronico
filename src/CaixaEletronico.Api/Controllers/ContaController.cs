using CaixaEletronico.Api.Models;
using CaixaEletronico.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CaixaEletronico.Api.Controllers;

[ApiController]
[Route("v1/conta")]
public class ContaController : Controller
{
    private List<Registro> _registros = new List<Registro>();
    private Conta conta;
    private int id = 0;

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
        if (model.Valor < 1) return BadRequest("Valor não permitido. Saques permitidos a partir de R$1.00");
        if (model.Valor > conta.Saldo) return BadRequest("Valor não permitido. Valor desejado é maior que seu saldo");

        var saque = new Registro();
        string tipo = "Saque";

        saque.Id = id++;
        saque.Tipo = tipo;
        saque.Valor = model.Valor;
        saque.Data = DateTime.Now;

        conta.Saldo -= model.Valor;

        _registros.Add(saque);

        return Ok($"Valor do saque: {model.Valor}");
    }

    [HttpGet("extrato")]
    public IActionResult Extrato()
    {
        return Ok(_registros);
    }

    [HttpGet("saldo")]
    public IActionResult Saldo()
    {
        return Ok($"Saldo: {conta.Saldo}");
    }
}
