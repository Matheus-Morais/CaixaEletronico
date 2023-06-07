using CaixaEletronico.Api.Models;
using CaixaEletronico.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CaixaEletronico.Api.Controllers;

[ApiController]
[Route("v1/conta")]
public class ContaController : Controller
{

    private List<Registro> _registros = new List<Registro>();
    private Conta conta = new Conta();
    private int id = 0;

    [HttpPost("depositar")]
    public IActionResult Depositar([FromBody] ValorViewModel model)
    {
        if (model.Valor < 0.1) return BadRequest("Valor não permitido. Deposite um valor entre R$0.10 e R$1000.00");

        var deposito = new Registro();

        string tipo = "Depósito";

        deposito.Id = id++;
        deposito.Tipo = tipo;
        deposito.Valor = model.Valor;
        deposito.Data = DateTime.Now;

        conta.Saldo += model.Valor;

        _registros.Add(deposito);

        return Ok($"Valor depositado: {model.Valor}");
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
