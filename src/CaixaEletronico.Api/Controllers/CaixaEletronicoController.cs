using CaixaEletronico.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaixaEletronico.Api.Controllers;

[ApiController]
[Route("v1/conta")]
public class CaixaEletronicoController : Controller
{
 
    private List<Registro> _registros = new List<Registro>();
    private Conta conta;
    private int id = 0;

    [HttpPost]

    public IActionResult Depositar(float valor)
    {
        if (valor < 0.1 || valor > 1000) return BadRequest("Valor não permitido. Deposite um valor entre R$0.10 e R$1000.00");

        var deposito = new Registro();

        string tipo = "Depósito";

        deposito.Id = id++;
        deposito.Tipo = tipo;
        deposito.valor = valor;
        deposito.data = DateTime.Now;

        conta.Saldo += valor;

        _registros.Add(deposito);

        return Ok($"Valor depositado: {valor}");
    }

    [HttpPost]

    public IActionResult Sacar(float valor)
    {
        if (valor < 1) return BadRequest("Valor não permitido. Saques permitidos a partir de R$1.00");
        if (valor > conta.Saldo) return BadRequest("Valor não permitido. Valor desejado é maior que seu saldo");

        var saque = new Registro();

        string tipo = "Saque";

        saque.Id = id++;
        saque.Tipo = tipo;
        saque.valor = valor;
        saque.data = DateTime.Now;

        conta.Saldo -= valor;

        _registros.Add(saque);

        return Ok($"Valor do saque: {valor}");
    }

    [HttpGet]

    public IActionResult Extrato() 
    {
        return View();
    }

    [HttpGet] 
    public IActionResult Saldo() 
    {
        return View();
    }
}
